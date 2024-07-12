using ErrorOr;
using MediatR;

namespace Employee.Permissions.Domain.Dtos.Responses.Permissions
{
    public record PermissionResponseGetAllDto() : IRequest<ErrorOr<IReadOnlyList<PermissionResponseDto>>>;
}
