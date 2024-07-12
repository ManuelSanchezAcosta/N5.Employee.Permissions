using ErrorOr;


namespace Employee.Permissions.Domain.DomainErrors
{
    public static partial class Errors
    {
        public static class Permissions
        {
            public static Error PermissionAlreadyExists =>
                Error.Validation("Permission", "Permission already exists");

        }
    }
}
