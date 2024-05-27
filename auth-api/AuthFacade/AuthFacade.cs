namespace AuthFacade;

public class AuthFacade : IAuthFacade
{
    public Task<bool> IsKnownUserAsync(string username, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}