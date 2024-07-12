using ErrorOr;

namespace Employee.Permissions.Domain.DomainErrors
{
    public static partial class Errors
    {
        public static class Employee
        {
            public static Error EmailAlreadyExists =>
                Error.Validation("Employee.Email", "Email Already Exists. Please Verify");

            public static Error EmployeeDoesNotExist =>
                Error.Validation("Employee", "Employee doesn't exist. Please Verify");

        }
    }
}
