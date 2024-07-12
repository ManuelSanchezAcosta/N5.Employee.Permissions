using ErrorOr;
using MediatR;

namespace Employee.Permissions.Domain.Dtos.Requests.PermissionTypes
{
    public record PermissonTypeCreateRequestDto(
        string Description) : IRequest<ErrorOr<string>>;

}
