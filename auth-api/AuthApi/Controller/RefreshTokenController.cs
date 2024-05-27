namespace AuthApi.Controller;

[ApiController]
[Route("refreshToken")]
public class RefreshTokenController(IAuthManager authManager) : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Post([FromBody] TokenModel token, CancellationToken cancellationToken)
    {
        var refreshedToken = await authManager.RefreshTokenAsync(token, cancellationToken);
        // SetJwtCookie(refreshedToken);

        return Ok(refreshedToken);
    }
}