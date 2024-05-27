namespace AuthApi.Controller;

[ApiController]
[Route("register")]
public class RegisterController(IUserManager userManager) : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    [ServiceFilter<GuardAgainstEmptyUsernameAndPassword>]
    [ServiceFilter<GuardAgainstDuplicatedUsername>]
    public async Task<IActionResult> Post([FromBody] UserModel user, CancellationToken cancellationToken)
    {
        var newUser = await userManager.CreateNewUserAsync(user, cancellationToken);

        return Created("/register", newUser);
    }
}