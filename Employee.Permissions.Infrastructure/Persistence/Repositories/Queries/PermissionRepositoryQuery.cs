using Employee.Permissions.Domain.Entities;
using Employee.Permissions.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Employee.Permissions.Domain.Interfaces.Repositories.Queries;

namespace Employee.Permissions.Infrastructure.Persistence.Repositories.Queries
{
    public class PermissionRepositoryQuery : IPermissionRepositoryQuery
    {
        private readonly ApplicationDbContext _context;

        public PermissionRepositoryQuery(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> ExistsAsync(Id id) => await _context.Permissions.AnyAsync(entity => entity.IdPermission == id);
        public async Task<PermissionEntity?> GetByIdAsync(Id id) => await _context.Permissions.SingleOrDefaultAsync(c => c.IdPermission == id);
        public async Task<PermissionEntity?> GetByEmployeeAndPermissionTypeAsync(Id idEmployee, Id idPermissionType) => await _context.Permissions.SingleOrDefaultAsync(c => c.IdEmployee == idEmployee && c.IdPermissionType == idPermissionType);
        public async Task<List<PermissionEntity>> GetAll() => await _context.Permissions.ToListAsync();
    }
}
