using MediatR;
using ErrorOr;

namespace Employee.Permissions.Domain.Dtos.Requests.Employees
{
    public record EmployeeCreateRequestDto(
        string Name,
        string LastName,
        string Email) : IRequest<ErrorOr<string>>;

}
