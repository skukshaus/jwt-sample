namespace AuthManager.Contract;

public interface ISecurityTokenGenerator
{
    string GenerateAccessToken(UserModel user);
    string GenerateRefreshToken(UserModel user);
}