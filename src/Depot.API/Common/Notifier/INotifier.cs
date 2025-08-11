using Depot.API.Common.Enums;

namespace Depot.API.Common.Notifier;

public interface INotifier
{
    void AddNotification(string message, EFeature feature);
    bool HasNotifies();
    IReadOnlyList<string> GetNotifications(EFeature? feature = null);
}
