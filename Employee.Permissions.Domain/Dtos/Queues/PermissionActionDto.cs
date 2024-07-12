
namespace Employee.Permissions.Domain.Dtos.Queues
{
    public record PermissionActionDto
    {
        public Guid Id { get; set; }
        public string OperationName { get; set; } = string.Empty;
    }
}
