namespace AuthApi.ServiceConfigurations;

public static class ConfigureAuthenticationExt
{
    public static void ConfigureAuthentication(this IServiceCollection services, ConfigurationManager settings) =>
        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = settings[AppSettingsPath.JwtIssuer],
                ValidAudience = settings[AppSettingsPath.JwtAudience],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings[AppSettingsPath.JwtAccessTokenSigningKey]!))
            });
}