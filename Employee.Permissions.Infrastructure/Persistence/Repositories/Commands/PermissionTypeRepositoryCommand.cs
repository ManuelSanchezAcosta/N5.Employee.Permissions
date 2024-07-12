using Employee.Permissions.Domain.Entities;
using Employee.Permissions.Domain.Interfaces.Repositories.Commands;

namespace Employee.Permissions.Infrastructure.Persistence.Repositories.Commands
{
    public class PermissionTypeRepositoryCommand : IPermissionTypeRepositoryCommand
    {
        private readonly ApplicationDbContext _context;

        public PermissionTypeRepositoryCommand(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(PermissionTypeEntity entity) => _context.PermissionTypes.Add(entity);
        public void Delete(PermissionTypeEntity entity) => _context.PermissionTypes.Remove(entity);
        public void Update(PermissionTypeEntity entity) => _context.PermissionTypes.Update(entity);
    }
}
