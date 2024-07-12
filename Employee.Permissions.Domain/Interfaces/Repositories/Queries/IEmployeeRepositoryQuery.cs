using Employee.Permissions.Domain.Entities;
using Employee.Permissions.Domain.ValueObjects;

namespace Employee.Permissions.Domain.Interfaces.Repositories.Queries
{
    public interface IEmployeeRepositoryQuery
    {
        Task<bool> ExistsAsync(Id id);
        Task<EmployeeEntity?> GetByIdAsync(Id id);
        Task<List<EmployeeEntity>> GetAll();
        Task<bool> ExistsEmailAsync(Email email);
    }
}
