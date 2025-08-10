namespace Depot.API.Common.Views;

public class ErrorResponseView(IReadOnlyList<string> errors, bool success = false) : BaseResponseView(success)
{
    public IReadOnlyList<string>? Errors { get; set; } = errors;
}
