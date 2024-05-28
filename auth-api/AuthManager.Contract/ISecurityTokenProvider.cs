namespace AuthManager.Contract;

public interface ISecurityTokenProvider
{
    public ISecurityTokenOptions TokenOptions { get; set; }

    public string GenerateSecureToken(UserModel user);
}