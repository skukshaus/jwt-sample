namespace AuthManager;

public class SecurityTokenOptionFactory(IConfiguration configuration) : ISecurityTokenOptionFactory
{
    public ISecurityTokenOptions GetAccessTokenOptions() => new AccessTokenOptions(configuration);

    public ISecurityTokenOptions GetRefreshTokenOptions() => new RefreshTokenOptions(configuration);
}