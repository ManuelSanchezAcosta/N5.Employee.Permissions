using Employee.Permissions.Application.Utils.Enums;
using Employee.Permissions.Domain.Dtos.Requests.Permissions;
using Employee.Permissions.Domain.Entities;
using Employee.Permissions.Domain.Interfaces.ElasticSearch;
using Employee.Permissions.Domain.Interfaces.QueueServices;
using Employee.Permissions.Domain.Interfaces.Repositories.Commands;
using Employee.Permissions.Domain.Interfaces.Repositories.Queries;
using Employee.Permissions.Domain.Primitives;
using Employee.Permissions.Domain.ValueObjects;
using ErrorOr;
using MediatR;
using Employee.Permissions.Domain.DomainErrors;

namespace Employee.Permissions.Application.Handlers.Permission.Commands.Create
{
    public class PermissionCreateCommandHandler : IRequestHandler<PermissionCreateRequestDto, ErrorOr<string>>
    {

        private readonly IPermissionRepositoryQuery _permissionRepositoryQuery;
        private readonly IPermissionRepositoryCommand _permissionRepositoryCommand;
        private readonly IEmployeeRepositoryQuery _employeeRepositoryQuery;
        private readonly IPermissionTypeRepositoryQuery _permissionTypeRepositoryQuery;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IPublishInQueue _publishInQueue;
        private readonly ISaveDocumentElasticRepository _saveDocumentElasticRepository;

        public PermissionCreateCommandHandler(
            IPermissionRepositoryQuery repositoryQuery,
            IPermissionRepositoryCommand repository,
            IEmployeeRepositoryQuery employeeRepositoryQuery,
            IPermissionTypeRepositoryQuery permissionTypeRepositoryQuery,
            IUnitOfWork unitOfWork,
            IPublishInQueue publishInQueue,
            ISaveDocumentElasticRepository saveDocumentElasticRepository)
        {
            _permissionRepositoryQuery = repositoryQuery;
            _permissionRepositoryCommand = repository ?? throw new ArgumentNullException(nameof(repository));
            _employeeRepositoryQuery = employeeRepositoryQuery;
            _permissionTypeRepositoryQuery = permissionTypeRepositoryQuery;
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _publishInQueue = publishInQueue;
            _saveDocumentElasticRepository = saveDocumentElasticRepository;
        }

        public async Task<ErrorOr<string>> Handle(PermissionCreateRequestDto request, CancellationToken cancellationToken)
        {
            PermissionEntity entity = null;
            string newID = string.Empty;

            var validations = await Validate(request);
            if (validations.IsError) return validations;

            newID = Guid.NewGuid().ToString();
            entity = new PermissionEntity(Id.Create(newID),
            Id.Create(request.IdEmployee),
            Id.Create(request.IdPermissionType),
            true);

            _permissionRepositoryCommand.Add(entity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            //Send to Queue
            await _publishInQueue.SendMessageToQueue(Helpers.Utils.messageForQueue(PermissionAction.Request_Action.GetEnumDescription()));

            //Save to ElasticSearch
            if (entity != null)
            {
                await _saveDocumentElasticRepository.AddDocument<PermissionEntity>(entity);
            }

            return newID;
        }

        private async Task<ErrorOr<string>> Validate(PermissionCreateRequestDto request)
        {
            var employee = await _employeeRepositoryQuery.GetByIdAsync(Id.Create(request.IdEmployee));
            if (employee is null) return Errors.Employee.EmployeeDoesNotExist;

            var permissionType = await _permissionTypeRepositoryQuery.GetByIdAsync(Id.Create(request.IdPermissionType));
            if (permissionType is null) return Errors.PermissionsType.PermissionTypeTypeDoesNotExist;


            var permissionInDB = await _permissionRepositoryQuery.GetByEmployeeAndPermissionTypeAsync(Id.Create(request.IdEmployee), Id.Create(request.IdPermissionType));            
            if (permissionInDB is not null) return Errors.Permissions.PermissionAlreadyExists;

            return string.Empty;
        }

    }
}
