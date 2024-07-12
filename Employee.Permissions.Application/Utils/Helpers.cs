using Employee.Permissions.Domain.Dtos.Queues;

namespace Employee.Permissions.Application.Helpers
{
    public static class Utils
    {
        public static PermissionActionDto messageForQueue(string action)
        {
            var message = new PermissionActionDto
            {
                Id = Guid.NewGuid(),
                OperationName = action
            };

            return message;
        }

    }
}
