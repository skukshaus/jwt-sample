namespace AuthApi.Controller;

[ApiController]
[Route("login")]
public class LoginController(IAuthManager authManager) : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Post([FromBody] UserLogin login, CancellationToken cancellationToken)
    {
        if (login.Username.IsNullOrEmpty() || login.Password.IsNullOrEmpty())
        {
            return BadRequest("username and password are required.");
        }

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