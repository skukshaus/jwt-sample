namespace AuthManager;

public class SecurityTokenProvider(IConfiguration configuration) : ISecurityTokenProvider
{
    public ISecurityTokenOptions TokenOptions { get; set; } = new ExceptionalSecurityTokenOptions();

    public string GenerateSecureToken(UserModel user)
    {
        var jwtConfig = configuration.GetSection("JWT");
        var issuer = jwtConfig["issuer"];
        var audience = jwtConfig["audience"];

        var tokenOptions = new JwtSecurityToken(
            issuer,
            audience,
            signingCredentials: GetSigningCredentials(),
            claims: TokenOptions.GetClaims(user),
            expires: TokenOptions.GetExpirationTime(),
            notBefore: DateTime.UtcNow
        );

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    private SigningCredentials GetSigningCredentials()
    {
        var signingKey = TokenOptions.GetBinarySigningKey();
        var securityKey = new SymmetricSecurityKey(signingKey);
        return new(securityKey, SecurityAlgorithms.HmacSha256);
    }
}