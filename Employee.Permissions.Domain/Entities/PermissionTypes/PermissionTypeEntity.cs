using Employee.Permissions.Domain.Primitives;
using Employee.Permissions.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Permissions.Domain.Entities
{
    public class PermissionTypeEntity : Audit
    {
        public Id IdPermissionType { get; init; }
        public Description Description { get; private set; }
        public bool Active { get; set; } = true;
        public List<PermissionEntity>? Permissions { get; set; }        


        public PermissionTypeEntity() { }

        public PermissionTypeEntity(Id id)
        {
            this.IdPermissionType = id;
        }

        public void SetDescription(Description description) => this.Description = description;


    }
}
