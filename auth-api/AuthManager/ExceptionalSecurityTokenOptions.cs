namespace AuthManager;

public class ExceptionalSecurityTokenOptions : ISecurityTokenOptions
{
    public string GetSigningKey() => throw new SecurityTokenException("invalid token options");

    public IEnumerable<Claim> GetClaims(UserModel user) => throw new SecurityTokenException("invalid token options");

    public DateTime GetExpirationTime() => throw new SecurityTokenException("invalid token options");
}