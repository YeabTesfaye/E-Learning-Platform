using Contracts;
using LoggerService;

namespace api.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) =>
 services.AddCors(options =>
 {
     options.AddPolicy("CorsPolicy", builder =>
     builder.WithOrigins("http:localhost:3000")
     .AllowAnyMethod()
     .AllowAnyHeader());
 });
 public static void ConfigureLoggerService(this IServiceCollection services){
    services.AddSingleton<ILoggerManager, LoggerManager>();
 }

}