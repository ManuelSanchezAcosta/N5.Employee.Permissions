using ErrorOr;
using MediatR;
using Employee.Permissions.Domain.Interfaces.Repositories.Queries;
using Employee.Permissions.Domain.Dtos.Responses.Permissions;
using Employee.Permissions.Domain.Entities;
using Employee.Permissions.Application.Utils.Enums;
using Employee.Permissions.Domain.Interfaces.QueueServices;

namespace PermissionType.Permissions.Application.Handlers.Permission.Queries
{
    public sealed class PermissionGetallQueryHandler : IRequestHandler<PermissionResponseGetAllDto, ErrorOr<IReadOnlyList<PermissionResponseDto>>>
    {

        private readonly IPermissionRepositoryQuery _PermissionQueryRepository;
        private readonly IPublishInQueue _publishInQueue;

        public PermissionGetallQueryHandler(IPermissionRepositoryQuery PermissionQueryRepository, IPublishInQueue publishInQueue)
        {
            _PermissionQueryRepository = PermissionQueryRepository ?? throw new ArgumentNullException(nameof(PermissionQueryRepository));
            _publishInQueue = publishInQueue;
        }

        public async Task<ErrorOr<IReadOnlyList<PermissionResponseDto>>> Handle(PermissionResponseGetAllDto query, CancellationToken cancellationToken)
        {
            IReadOnlyList<PermissionEntity> Permissions = await _PermissionQueryRepository.GetAll();

            await _publishInQueue.SendMessageToQueue(Employee.Permissions.Application.Helpers.Utils.messageForQueue(PermissionAction.Request_Action.GetEnumDescription()));

            return Permissions.Select(Permission => new PermissionResponseDto(
                    Permission.IdPermission.Value.ToString(),
                    Permission.IdEmployee.Value.ToString(),
                    Permission.IdPermissionType.Value.ToString(),
                    Permission.Active
                )).ToList();
        }

    }
}
