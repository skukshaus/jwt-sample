namespace AuthManager;

public class AuthManagerFacade : IAuthManager
{
    public Task<UserModel?> AuthenticateAsync(UserLogin login, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<TokenModel> GenerateTokenAsync(UserModel user, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<TokenModel> RefreshTokenAsync(TokenModel token, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}