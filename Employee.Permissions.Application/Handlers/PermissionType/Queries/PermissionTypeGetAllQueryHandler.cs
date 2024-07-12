using Employee.Permissions.Domain.Interfaces.Repositories.Queries;
using ErrorOr;
using MediatR;
using Employee.Permissions.Domain.Dtos.Responses.PermissionTypes;
using Employee.Permissions.Domain.Entities;

namespace Employee.PermissionTypes.Application.Handlers.PermissionTypeType.Queries
{
    public sealed class PermissionTypeTypeGetAllQueryHandler : IRequestHandler<PermissionTypeResponseGetAllDto, ErrorOr<IReadOnlyList<PermissionTypeResponseDto>>>
    {
        private readonly IPermissionTypeRepositoryQuery _PermissionTypeQueryRepository;

        public PermissionTypeTypeGetAllQueryHandler(IPermissionTypeRepositoryQuery PermissionTypeQueryRepository)
        {
            _PermissionTypeQueryRepository = PermissionTypeQueryRepository ?? throw new ArgumentNullException(nameof(PermissionTypeQueryRepository));
        }

        public async Task<ErrorOr<IReadOnlyList<PermissionTypeResponseDto>>> Handle(PermissionTypeResponseGetAllDto query, CancellationToken cancellationToken)
        {
            IReadOnlyList<PermissionTypeEntity> PermissionTypes = await _PermissionTypeQueryRepository.GetAll();

            return PermissionTypes.Select(PermissionType => new PermissionTypeResponseDto(
                    PermissionType.IdPermissionType.Value.ToString(),
                    PermissionType.Description.Value.ToString(),                    
                    PermissionType.Active
                )).ToList();
        }
    }
}
