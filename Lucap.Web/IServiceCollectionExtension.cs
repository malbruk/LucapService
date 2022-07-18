namespace Lucap.Web
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddGoogleStorageService(this IServiceCollection services, IConfiguration namedConfigurationSection)
        {
            services.Configure<GoogleStorageManagerOptions>(namedConfigurationSection);
            services.AddScoped<GoogleStorageManager>();
            return services;
        }
    }
}
