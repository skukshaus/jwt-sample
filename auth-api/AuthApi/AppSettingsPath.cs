namespace AuthApi;

public static class AppSettingsPath
{
    public const string JwtIssuer = "JWT:Issuer";
    public const string JwtAudience = "JWT:Audience";
    public const string JwtAccessTokenSigningKey = "JWT:AccessTokenSigningKey";
    public const string JwtRefreshTokenSigningKey = "JWT:RefreshTokenSigningKey";
    public const string JwtAccessTokenExpirationInMinutes = "JWT:AccessTokenExpirationInMinutes";
    public const string JwtRefreshTokenExpirationInHours = "JWT:RefreshTokenExpirationInHours";
}