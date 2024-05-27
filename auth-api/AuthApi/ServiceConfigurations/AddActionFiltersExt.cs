namespace AuthApi.ServiceConfigurations;

public static class AddActionFiltersExt
{
    public static void AddActionFilters(this IServiceCollection services) => services
        .AddScoped<GuardAgainstEmptyUsernameAndPassword>()
        .AddScoped<GuardAgainstDuplicatedUsername>();
}