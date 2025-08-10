using Depot.API.Common.Enums;
using Microsoft.OpenApi.Extensions;

namespace Depot.API.Common.Notifier;

public class Notification(string message, EFeature feature)
{
    public string Message { get; private set; } = message;
    public EFeature Feature { get; private set; } = feature;

    public string GetNotificationText() => 
        $"{Message} at {Feature.GetDisplayName()}";
}
