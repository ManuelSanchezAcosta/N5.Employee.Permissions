using Employee.Permissions.Domain.ValueObjects;

namespace Employee.Permissions.Domain.Entities
{
    public class EmployeeEntity : Audit
    {

        public Id IdEmployee { get; init; }
        public Name Name { get; private set; }
        public LastName LastName { get; private set; }
        public Email Email { get; private set; }
        public bool Active { get; set; } = true;

        public List<PermissionEntity>? Permissions { get; set; }


        public EmployeeEntity() { }

        public EmployeeEntity(Id id)
        {
            this.IdEmployee = id;
        }

        public void SetName(Name name) => this.Name = name;
        public void SetLastName(LastName lastName) => this.LastName = lastName;
        public void SetEmail(Email email) => this.Email = email;

    }
}
