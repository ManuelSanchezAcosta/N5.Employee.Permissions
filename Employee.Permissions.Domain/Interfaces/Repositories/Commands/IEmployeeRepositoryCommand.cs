using Employee.Permissions.Domain.Entities;

namespace Employee.Permissions.Domain.Interfaces.Repositories.Commands
{
    public interface IEmployeeRepositoryCommand
    {
        public void Add(EmployeeEntity employee);
        public void Delete(EmployeeEntity employee);
        public void Update(EmployeeEntity employee);

    }
}
