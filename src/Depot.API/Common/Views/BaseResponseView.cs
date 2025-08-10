namespace Depot.API.Common.Views;

public class BaseResponseView(bool success)
{
    public bool Success { get; set; } = success;
}
