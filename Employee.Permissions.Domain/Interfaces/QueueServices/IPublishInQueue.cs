namespace Employee.Permissions.Domain.Interfaces.QueueServices
{
    public interface IPublishInQueue
    {
        Task SendMessageToQueue<T>(T data);
    }
}
