namespace AuthManager;

public class AuthManagerFacade(
    ISecurityTokenGenerator tokenGenerator,
    IUserRepository users,
    ISecurityTokenOptionFactory tokenOptionFactory
) : IAuthManager
{
    public Task<UserModel?> AuthenticateAsync(UserLogin login, CancellationToken cancellationToken = default)
        => users.GetUserByLoginAsync(login with { Password = login.Password.Hashify() }, cancellationToken);

    public async Task<TokenModel> GenerateTokenAsync(UserModel user, CancellationToken cancellationToken = default)
    {
        var accessToken = tokenGenerator.GenerateAccessToken(user);

        user = await UpdateUserAsync(user, cancellationToken);
        var refreshToken = user.RefreshTokens[^1].Token;

        return new TokenModel(accessToken, refreshToken);
    }

    public Task<TokenModel> RefreshTokenAsync(TokenModel token, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    private async Task<UserModel> UpdateUserAsync(UserModel user, CancellationToken cancellationToken)
    {
        var refreshTokenOptions = tokenOptionFactory.GetRefreshTokenOptions();
        
        var refreshToken = new RefreshTokenModel(
            Token: tokenGenerator.GenerateRefreshToken(user),
            ExpirationTime: refreshTokenOptions.GetExpirationTime(),
            ClientName: "",
            UserAgent: "",
            RemoteAddr: ""
        );
        
        user = user with {
            RefreshTokens = [..user.RefreshTokens, refreshToken]
        };

        return await users.UpdateUserAsync(user, cancellationToken);
    }
}