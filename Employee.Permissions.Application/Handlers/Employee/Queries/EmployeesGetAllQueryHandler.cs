using Employee.Permissions.Domain.Dtos.Responses.Employees;
using Employee.Permissions.Domain.Entities;
using Employee.Permissions.Domain.Interfaces.Repositories.Queries;
using ErrorOr;
using MediatR;

namespace Employee.Permissions.Application.Handlers.Employee.Queries
{
    public sealed class EmployeesGetAllQueryHandler : IRequestHandler<EmployeeResponseGetAllDto, ErrorOr<IReadOnlyList<EmployeeResponseDto>>>
    {

        private readonly IEmployeeRepositoryQuery _employeeQueryRepository;

        public EmployeesGetAllQueryHandler(IEmployeeRepositoryQuery employeeQueryRepository)
        {
            _employeeQueryRepository = employeeQueryRepository ?? throw new ArgumentNullException(nameof(employeeQueryRepository));
        }

        public async Task<ErrorOr<IReadOnlyList<EmployeeResponseDto>>> Handle(EmployeeResponseGetAllDto query, CancellationToken cancellationToken)
        {
            IReadOnlyList<EmployeeEntity> employees = await _employeeQueryRepository.GetAll();

            return employees.Select(employee => new EmployeeResponseDto(
                    employee.IdEmployee.Value,
                    employee.Name.Value.ToString(),
                    employee.LastName.Value.ToString(),
                    employee.Email.Value.ToString(),
                    employee.Active
                )).ToList();
        }

    }
}
