using Microsoft.AspNetCore.Cors.Infrastructure;

namespace AuthApi.ServiceConfigurations;

public static class ConfigureCorsExt
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(
            options =>
            {
                options.AddDefaultPolicy(BuildDefaultPolicy);
                options.AddPolicy("CorsPolicyAllowAny", BuildAllowAnyPolicy);
            }
        );

    private static void BuildDefaultPolicy(CorsPolicyBuilder policy) =>
        policy.SetIsOriginAllowed(origin => new Uri(origin).IsLoopback);

    private static void BuildAllowAnyPolicy(CorsPolicyBuilder policy) =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}