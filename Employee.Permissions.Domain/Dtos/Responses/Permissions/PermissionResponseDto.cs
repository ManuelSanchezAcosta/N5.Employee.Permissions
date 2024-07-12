namespace Employee.Permissions.Domain.Dtos.Responses.Permissions
{
    public record PermissionResponseDto(string IdPermission, string IdEmployee, string IdPermissionType, bool Active);

}
