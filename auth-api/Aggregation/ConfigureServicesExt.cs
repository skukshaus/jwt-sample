namespace Aggregation;

public static class ConfigureServicesExt
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services) => services
        .AddScoped<IUserRepository, UserRepository>()
            
        .AddScoped<IUserManager, UserManagerFacade>()
        .AddScoped<IAuthManager, AuthManagerFacade>();
}