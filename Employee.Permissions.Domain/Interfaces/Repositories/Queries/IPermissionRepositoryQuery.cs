using Employee.Permissions.Domain.Entities;
using Employee.Permissions.Domain.ValueObjects;

namespace Employee.Permissions.Domain.Interfaces.Repositories.Queries
{
    public interface IPermissionRepositoryQuery
    {
        Task<bool> ExistsAsync(Id id);
        Task<PermissionEntity?> GetByIdAsync(Id id);
        Task<PermissionEntity?> GetByEmployeeAndPermissionTypeAsync(Id idEmployee, Id idPermissionType);
        Task<List<PermissionEntity>> GetAll();
    }
}
