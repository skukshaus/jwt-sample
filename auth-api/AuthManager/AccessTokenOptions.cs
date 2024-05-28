namespace AuthManager;

public class AccessTokenOptions(IConfiguration configuration) : ISecurityTokenOptions
{
    private readonly IConfigurationSection _jwtConfig = configuration.GetSection("jwt");

    public string GetSigningKey() =>
        _jwtConfig["accessTokenSigningKey"]
        ?? throw new SecurityException("missing config option jwt:accessTokenSigningKey");

    public IEnumerable<Claim> GetClaims(UserModel user) => new[] {
        new Claim(ClaimTypes.NameIdentifier, user.Username), new Claim(ClaimTypes.Email, user.Email),
    };

    public DateTime GetExpirationTime()
    {
        _ = int.TryParse(_jwtConfig["accessTokenExpirationInMinutes"], out var minutes);

        if (minutes == 0)
            minutes = 15;
        
        return DateTime.UtcNow.AddMinutes(minutes);
    }
}