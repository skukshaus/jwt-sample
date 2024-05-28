namespace AuthApi.Controller;

[ApiController]
[Route("register")]
public class RegisterController(IUserManager userManager) : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Post([FromBody] UserMetadata user, CancellationToken cancellationToken)
    {
        if (user.Username.IsNullOrEmpty() || user.Password.IsNullOrEmpty())
        {
            return BadRequest("username and password are required.");
        }
        
        if (await userManager.IsKnownUserAsync(user.Username, cancellationToken))
        {
            return Conflict("username already taken.");
        }

        var newUser = await userManager.CreateNewUserAsync(user, cancellationToken);

        return Created("/register", newUser);
    }
}