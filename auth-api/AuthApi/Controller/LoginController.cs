namespace AuthApi.Controller;

[ApiController]
[Route("login")]
public class LoginController(IAuthManager authManager) : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    [ServiceFilter<GuardAgainstEmptyUsernameAndPassword>]
    public async Task<IActionResult> Post([FromBody] UserLogin login, CancellationToken cancellationToken)
    {
        var user = await authManager.AuthenticateAsync(login, cancellationToken);

        if (user == null)
        {
            return Unauthorized(new MessageResult("user not found"));
        }

        var token = await authManager.GenerateTokenAsync(user, cancellationToken);
        //SetJwtCookie(token);

        return Ok(token);
    }
}