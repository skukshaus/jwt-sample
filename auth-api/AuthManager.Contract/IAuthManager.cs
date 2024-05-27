namespace AuthManager.Contract;

public interface IAuthManager
{
    Task<UserModel?> AuthenticateAsync(UserLogin login, CancellationToken cancellationToken = default);
    Task<TokenModel> GenerateTokenAsync(UserModel user, CancellationToken cancellationToken = default);
    Task<TokenModel> RefreshTokenAsync(TokenModel token, CancellationToken cancellationToken = default);
}