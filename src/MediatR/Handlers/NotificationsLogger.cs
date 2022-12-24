namespace JustinWritesCode.MediatR.Notifications;
using Microsoft.Extensions.Logging;

public class NotificationsLogger<TNotification> : IRequestHandler<TNotification, Unit>
    where TNotificatin : INotofication
{
    private readonly ILogger<NotificationsLogger> _logger;

    public NotificationsLogger(ILogger<NotificationsLogger> logger)
    {
        _logger = logger;
    }

    public Task<Unit> Handle(INotification notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Notification: {Notification}", notification);
        return Task.FromResult(Unit.Value);
    }
}
