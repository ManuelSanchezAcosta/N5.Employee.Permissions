using Employee.Permissions.Domain.Entities;

namespace Employee.Permissions.Domain.Interfaces.Repositories.Commands
{
    public interface IPermissionRepositoryCommand
    {
        public void Add(PermissionEntity permission);
        public void Delete(PermissionEntity permission);
        public void Update(PermissionEntity permission);
    }
}
