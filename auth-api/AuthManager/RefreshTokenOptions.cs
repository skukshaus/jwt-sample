namespace AuthManager;

public class RefreshTokenOptions(IConfiguration configuration) : ISecurityTokenOptions
{
    private readonly IConfigurationSection _jwtConfig = configuration.GetSection("jwt");

    public string GetSigningKey() =>
        _jwtConfig["refreshTokenSigningKey"]
        ?? throw new SecurityException("missing config option jwt:refreshTokenSigningKey");
    
    public IEnumerable<Claim> GetClaims(UserModel user) => new[] {
        new Claim(ClaimTypes.NameIdentifier, user.Username),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim("passwd", user.Password)
    };

    public DateTime GetExpirationTime()
    {
        _ = int.TryParse(_jwtConfig["refreshTokenExpirationInHours"], out var hours);

        if (hours == 0)
            hours = 24;
        
        return DateTime.UtcNow.AddHours(hours);
    }
}