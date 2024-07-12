using Employee.Permissions.Domain.Entities;

namespace Employee.Permissions.Domain.Interfaces.Repositories.Commands
{
    public interface IPermissionTypeRepositoryCommand
    {
        public void Add(PermissionTypeEntity permissionType);
        public void Delete(PermissionTypeEntity permissionType);
        public void Update(PermissionTypeEntity permissionType);
    }
}
