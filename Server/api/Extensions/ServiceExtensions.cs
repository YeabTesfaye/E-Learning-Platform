namespace api.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", policy =>
              policy.WithOrigins("http://localhost:3000")
               .AllowAnyMethod()
               .AllowAnyHeader());
        });
    }
}