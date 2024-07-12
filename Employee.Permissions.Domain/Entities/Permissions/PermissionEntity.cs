using Employee.Permissions.Domain.ValueObjects;

namespace Employee.Permissions.Domain.Entities
{
    public class PermissionEntity : Audit
    {
        public Id IdPermission { get; init; }
        public Id IdEmployee { get; private set; }
        public Id IdPermissionType { get; private set; }
        public bool Active { get; set; } = true;


        public EmployeeEntity? Employee { get; private set; }
                
        public PermissionTypeEntity? PermissionType { get; private set; }

        
        public PermissionEntity() { }

        public PermissionEntity(Id id, Id idEmployee, Id idPermissionType, bool active)
        {
            this.IdPermission = id;
            this.IdEmployee = idEmployee;
            this.IdPermissionType = idPermissionType;
            this.Active = active;
        }
        
    }
}
