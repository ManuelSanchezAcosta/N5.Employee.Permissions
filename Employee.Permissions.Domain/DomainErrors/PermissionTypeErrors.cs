using ErrorOr;


namespace Employee.Permissions.Domain.DomainErrors
{
    public static partial class Errors
    {
        public static class PermissionsType
        {
            public static Error PermissionTypeTypeDoesNotExist =>
                Error.Validation("PermissionType", "PermissionType doesn't exist. Please Verify");

        }
    }
}
