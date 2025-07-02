using FSH.WebApi.Shared.Notifications;

namespace Project1.Client.Infrastructure.Notifications;
public record ConnectionStateChanged(ConnectionState State, string? Message) : INotificationMessage;