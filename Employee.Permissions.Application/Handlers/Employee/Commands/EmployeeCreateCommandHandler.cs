using Employee.Permissions.Domain.Dtos.Requests.Employees;
using Employee.Permissions.Domain.Entities;
using Employee.Permissions.Domain.Interfaces.QueueServices;
using Employee.Permissions.Domain.Interfaces.Repositories.Commands;
using Employee.Permissions.Domain.Interfaces.Repositories.Queries;
using Employee.Permissions.Domain.Primitives;
using Employee.Permissions.Domain.ValueObjects;
using ErrorOr;
using MediatR;
using Employee.Permissions.Domain.DomainErrors;
using Employee.Permissions.Domain.Interfaces.ElasticSearch;

namespace Employee.Permissions.Application.Handlers.Employee.Commands
{
    public sealed class EmployeeCreateCommandHandler : IRequestHandler<EmployeeCreateRequestDto, ErrorOr<string>>
    {
        private readonly IEmployeeRepositoryCommand _repositoryCommand;
        private readonly IEmployeeRepositoryQuery _repositoryQuery;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPublishInQueue _publishInQueue;
        private readonly ISaveDocumentElasticRepository _saveDocumentElasticRepository;

        public EmployeeCreateCommandHandler(
            IEmployeeRepositoryCommand repositoryCommand,
            IEmployeeRepositoryQuery repositoryQuery,
            IUnitOfWork unitOfWork,
            IPublishInQueue publishInQueue,
            ISaveDocumentElasticRepository saveDocumentElasticRepository)
        {
            _repositoryCommand = repositoryCommand ?? throw new ArgumentNullException(nameof(repositoryCommand));
            _repositoryQuery = repositoryQuery ?? throw new ArgumentNullException(nameof(repositoryQuery));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _publishInQueue = publishInQueue;
            _saveDocumentElasticRepository = saveDocumentElasticRepository;
        }
        public async Task<ErrorOr<string>> Handle(EmployeeCreateRequestDto request, CancellationToken cancellationToken)
        {

            var entity = new EmployeeEntity(Id.Create(Guid.NewGuid().ToString()));
            entity.SetName(Name.Create(request.Name));
            entity.SetLastName(LastName.Create(request.LastName));
            entity.SetEmail(Email.Create(request.Email));
            entity.Active = true;

            var validations = await Validate(entity);
            if (validations.IsError) return validations;

            _repositoryCommand.Add(entity);            

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _saveDocumentElasticRepository.AddDocument<EmployeeEntity>(entity);

            return entity.IdEmployee.Value;
        }

        private async Task<ErrorOr<string>> Validate(EmployeeEntity entity)
        {
            var existeEmail = await _repositoryQuery.ExistsEmailAsync(entity.Email);
            if (existeEmail) return Errors.Employee.EmailAlreadyExists;
            return string.Empty;
        }


    }
}
