using ErrorOr;
using MediatR;

namespace Employee.Permissions.Domain.Dtos.Responses.PermissionTypes
{
    public record PermissionTypeResponseGetAllDto() : IRequest<ErrorOr<IReadOnlyList<PermissionTypeResponseDto>>>;
}
