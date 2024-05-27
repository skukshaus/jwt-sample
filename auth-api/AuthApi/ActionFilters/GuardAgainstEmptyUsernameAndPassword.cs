namespace AuthApi.ActionFilters;

public class GuardAgainstEmptyUsernameAndPassword : ActionFilterBase
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var user = GetParamsOfType<UserLogin>(context).Single() ?? new UserLogin("", "");

        if (user.Username.IsNullOrEmpty() || user.Password.IsNullOrEmpty())
        {
            context.Result = BadRequest("username and password are required.");
        }
        else
        {
            await next();
        }
    }
}