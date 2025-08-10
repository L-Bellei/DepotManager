using Depot.API.Common.Enums;
using Depot.API.Common.Interfaces;

namespace Depot.API.Common.Notifier;

public class Notifier: INotifier
{
    public List<Notification> Notifications { get; set; }

    public Notifier()
    {
        Notifications = [];
    }

    public void AddNotification(string message, EFeature feature) =>
        Notifications.Add(new Notification(message, feature));

    public bool HasNotifies() =>
        Notifications.Count != 0;

    public IReadOnlyList<string> GetNotifications(EFeature? feature = null)
    {
        if (feature is null)
            return [.. Notifications
                .Where(notification => notification.Feature == feature)
                .Select(message => message.GetNotificationText())];

        return [.. Notifications
            .Select(notification => notification.GetNotificationText())];
    }
}
