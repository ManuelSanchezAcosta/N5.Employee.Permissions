using Employee.Permissions.Domain.Entities;
using Employee.Permissions.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Employee.Permissions.Domain.Interfaces.Repositories.Queries;

namespace Employee.Permissions.Infrastructure.Persistence.Repositories.Queries
{
    public class PermissionTypeRepositoryQuery : IPermissionTypeRepositoryQuery
    {
        private readonly ApplicationDbContext _context;

        public PermissionTypeRepositoryQuery(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> ExistsAsync(Id id) => await _context.PermissionTypes.AnyAsync(entity => entity.IdPermissionType == id);
        public async Task<PermissionTypeEntity?> GetByIdAsync(Id id) => await _context.PermissionTypes.SingleOrDefaultAsync(c => c.IdPermissionType == id);
        public async Task<List<PermissionTypeEntity>> GetAll() => await _context.PermissionTypes.ToListAsync();
    }
}
