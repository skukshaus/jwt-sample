namespace AuthApi.Controller;

[ApiController]
[Route("logout")]
public class LogoutController : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Post(CancellationToken cancellationToken)
    {
        await Task.Yield();
        return Ok();
    }
}