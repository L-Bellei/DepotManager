using Depot.API.Common.Notifier;

namespace Depot.API.Common.Services;

public abstract class BaseService(INotifier notifier)
{
    protected INotifier _notifier = notifier;
}
