namespace AuthApi.Controller;

[ApiController]
[Route("heartbeat")]
public class HeartbeatController : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Get() => Ok(new AliveMessageResult());
}