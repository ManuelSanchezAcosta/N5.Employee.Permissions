using ErrorOr;
using MediatR;

namespace Employee.Permissions.Domain.Dtos.Requests.Permissions
{
    public record PermissionDeleteRequestDto(
        string IdEmployee,
        string IdPermissionType) : IRequest<ErrorOr<Unit>>;
}
