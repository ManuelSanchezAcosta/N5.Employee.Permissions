using MediatR;
using ErrorOr;

namespace Employee.Permissions.Domain.Dtos.Responses.Employees
{
    public record EmployeeResponseGetAllDto() : IRequest<ErrorOr<IReadOnlyList<EmployeeResponseDto>>>;
}
