using Employee.Permissions.Domain.Dtos.Requests.Permissions;
using Employee.Permissions.Domain.Dtos.Requests.PermissionTypes;
using Employee.Permissions.Domain.Entities;
using Employee.Permissions.Domain.Interfaces.ElasticSearch;
using Employee.Permissions.Domain.Interfaces.QueueServices;
using Employee.Permissions.Domain.Interfaces.Repositories.Commands;
using Employee.Permissions.Domain.Primitives;
using Employee.Permissions.Domain.ValueObjects;
using ErrorOr;
using MediatR;


namespace Employee.Permissions.Application.Handlers.PermissionType.Command
{
    public sealed class PermissionTypeCreateCommandHandler : IRequestHandler<PermissonTypeCreateRequestDto, ErrorOr<string>>
    {
        private readonly IPermissionTypeRepositoryCommand _repositoryCommand;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPublishInQueue _publishInQueue;
        private readonly ISaveDocumentElasticRepository _saveDocumentElasticRepository;

        public PermissionTypeCreateCommandHandler(
            IPermissionTypeRepositoryCommand repositoryCommand,
            IUnitOfWork unitOfWork,
            IPublishInQueue publishInQueue,
            ISaveDocumentElasticRepository saveDocumentElasticRepository)
        {
            _repositoryCommand = repositoryCommand ?? throw new ArgumentNullException(nameof(repositoryCommand));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _publishInQueue = publishInQueue;
            _saveDocumentElasticRepository = saveDocumentElasticRepository;
        }
        public async Task<ErrorOr<string>> Handle(PermissonTypeCreateRequestDto request, CancellationToken cancellationToken)
        {

            var entity = new PermissionTypeEntity(Id.Create(Guid.NewGuid().ToString()));
            entity.SetDescription(Description.Create(request.Description));
            entity.Active = true;

            _repositoryCommand.Add(entity);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _saveDocumentElasticRepository.AddDocument<PermissionTypeEntity>(entity);

            return entity.IdPermissionType.Value;
        }

    }
}
