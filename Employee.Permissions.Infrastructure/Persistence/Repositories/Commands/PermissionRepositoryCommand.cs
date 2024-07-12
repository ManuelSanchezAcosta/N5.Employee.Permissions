using Employee.Permissions.Domain.Entities;
using Employee.Permissions.Domain.Interfaces.Repositories.Commands;

namespace Employee.Permissions.Infrastructure.Persistence.Repositories.Commands
{
    public class PermissionRepositoryCommand : IPermissionRepositoryCommand
    {
        private readonly ApplicationDbContext _context;

        public PermissionRepositoryCommand(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(PermissionEntity entity) => _context.Permissions.Add(entity);
        public void Delete(PermissionEntity entity) => _context.Permissions.Remove(entity);
        public void Update(PermissionEntity entity) => _context.Permissions.Update(entity);
    }
}
