using Employee.Permissions.Domain.Entities;
using Employee.Permissions.Domain.Interfaces.Repositories.Commands;

namespace Employee.Permissions.Infrastructure.Persistence.Repositories.Commands
{
    public class EmployeeRepositoryCommand : IEmployeeRepositoryCommand
    {

        private readonly ApplicationDbContext _context;

        public EmployeeRepositoryCommand(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(EmployeeEntity entity) => _context.Employees.Add(entity);
        public void Delete(EmployeeEntity entity) => _context.Employees.Remove(entity);
        public void Update(EmployeeEntity entity) => _context.Employees.Update(entity);
    }
}
