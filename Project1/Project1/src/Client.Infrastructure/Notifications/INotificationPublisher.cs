using FSH.WebApi.Shared.Notifications;

namespace Project1.Client.Infrastructure.Notifications;
public interface INotificationPublisher
{
    Task PublishAsync(INotificationMessage notification);
}