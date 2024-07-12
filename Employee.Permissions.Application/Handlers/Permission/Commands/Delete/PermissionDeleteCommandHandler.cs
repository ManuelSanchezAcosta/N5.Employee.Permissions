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

namespace Employee.Permissions.Application.Handlers.Permission.Commands.Delete
{
    public class PermissionDeleteCommandHandler : IRequestHandler<PermissionDeleteRequestDto, ErrorOr<Unit>>
    {

        private readonly IPermissionRepositoryQuery _permissionRepositoryQuery;
        private readonly IPermissionRepositoryCommand _permissionRepositoryCommand;
        private readonly IEmployeeRepositoryQuery _employeeRepositoryQuery;
        private readonly IPermissionTypeRepositoryQuery _permissionTypeRepositoryQuery;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IPublishInQueue _publishInQueue;
        private readonly ISaveDocumentElasticRepository _saveDocumentElasticRepository;

        public PermissionDeleteCommandHandler(
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

        public async Task<ErrorOr<Unit>> Handle(PermissionDeleteRequestDto request, CancellationToken cancellationToken)
        {

            if (await _permissionRepositoryQuery.GetByEmployeeAndPermissionTypeAsync(Id.Create(request.IdEmployee), Id.Create(request.IdPermissionType)) is not PermissionEntity permissionInBD)
            {
                return Error.NotFound("Permission was not found");
            }

            _permissionRepositoryCommand.Delete(permissionInBD);            
            await _unitOfWork.SaveChangesAsync(cancellationToken);


            //Send to Queue
            await _publishInQueue.SendMessageToQueue(Helpers.Utils.messageForQueue(PermissionAction.Modify_Action.GetEnumDescription()));

            await _saveDocumentElasticRepository.AddDocument(permissionInBD);

            return Unit.Value;
        }

    }
}
