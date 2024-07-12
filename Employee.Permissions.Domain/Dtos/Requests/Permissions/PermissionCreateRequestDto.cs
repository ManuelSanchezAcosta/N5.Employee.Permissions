using ErrorOr;
using MediatR;

namespace Employee.Permissions.Domain.Dtos.Requests.Permissions
{
    public record PermissionCreateRequestDto(
        string IdEmployee,
        string IdPermissionType) : IRequest<ErrorOr<string>>;

}
