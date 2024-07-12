using Employee.Permissions.Domain.Entities;
using Employee.Permissions.Domain.Interfaces.Repositories.Queries;
using Employee.Permissions.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;


namespace Employee.Permissions.Infrastructure.Persistence.Repositories.Queries
{
    public class EmployeeRepositoryQuery : IEmployeeRepositoryQuery
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepositoryQuery(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> ExistsAsync(Id id) => await _context.Employees.AnyAsync(entity => entity.IdEmployee == id);
        public async Task<EmployeeEntity?> GetByIdAsync(Id id) => await _context.Employees.SingleOrDefaultAsync(c => c.IdEmployee == id);
        public async Task<List<EmployeeEntity>> GetAll() => await _context.Employees.ToListAsync();
        public async Task<bool> ExistsEmailAsync(Email email) => await _context.Employees.AnyAsync(entity => entity.Email == email);

    }
}
