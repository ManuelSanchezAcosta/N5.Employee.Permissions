using Employee.Permissions.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee.Permissions.Application.Data
{
    public interface IApplicationDbContext
    {

        DbSet<EmployeeEntity> Employees { get; set; }
        DbSet<PermissionTypeEntity> PermissionTypes { get; set; }        
        DbSet<PermissionEntity> Permissions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
