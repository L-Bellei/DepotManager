namespace Depot.API.Common.Views;

public class SuccessResponseView(object data, bool success = true) : BaseResponseView(success)
{
    public object Data { get; set; } = data;
}
