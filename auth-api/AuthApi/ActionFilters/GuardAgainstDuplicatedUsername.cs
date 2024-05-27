namespace AuthApi.ActionFilters;

public class GuardAgainstDuplicatedUsername(IUserManager userManager) : ActionFilterBase
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var user = GetParamsOfType<UserModel>(context).Single() ?? new UserModel("", "");

        if (await userManager.IsKnownUserAsync(user.Username))
        {
            context.Result = Conflict("username already taken.");
        }
        else
        {
            await next();
        }
    }
}