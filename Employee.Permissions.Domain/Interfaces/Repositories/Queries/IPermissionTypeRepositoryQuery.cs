using Employee.Permissions.Domain.Entities;
using Employee.Permissions.Domain.ValueObjects;

namespace Employee.Permissions.Domain.Interfaces.Repositories.Queries
{
    public interface IPermissionTypeRepositoryQuery
    {
        Task<bool> ExistsAsync(Id id);
        Task<PermissionTypeEntity?> GetByIdAsync(Id id);
        Task<List<PermissionTypeEntity>> GetAll();
    }
}
