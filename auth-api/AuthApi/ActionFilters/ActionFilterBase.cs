namespace AuthApi.ActionFilters;

public abstract class ActionFilterBase : IAsyncActionFilter
{
    public abstract Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next);

    protected IEnumerable<T?> GetParamsOfType<T>(ActionExecutingContext context) =>
        context.ActionArguments.Where(p => p.Value is T)
            .Select(p => p.Value)
            .Cast<T?>();

    protected IActionResult BadRequest(string message) => new BadRequestObjectResult(new MessageResult(message));
    protected IActionResult Conflict(string message) => new ConflictObjectResult(new MessageResult(message));
}