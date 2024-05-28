namespace AuthManager;

public class SecurityTokenGenerator(ISecurityTokenProvider tokenProvider, ISecurityTokenOptionFactory optionFactory)
    : ISecurityTokenGenerator
{
    public string GenerateAccessToken(UserModel user)
    {
        tokenProvider.TokenOptions = optionFactory.GetAccessTokenOptions();
        return tokenProvider.GenerateSecureToken(user);
    }

    public string GenerateRefreshToken(UserModel user)
    {
        tokenProvider.TokenOptions = optionFactory.GetRefreshTokenOptions();
        return tokenProvider.GenerateSecureToken(user);
    }
}