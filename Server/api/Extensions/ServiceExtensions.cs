using System.Text;
using AspNetCoreRateLimit;
using Contracts;
using Entities;
using Entities.configurationModel;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Service.Impl;
using Service.Intefaces;

namespace api.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) =>
 services.AddCors(options =>
 {
     options.AddPolicy("CorsPolicy", builder =>
     builder.AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());
 });
   
    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
    services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureServiceManager(this IServiceCollection services) =>
         services.AddScoped<IServiceManager, ServiceManager>();

    public static void ConfigureSqlContext(this IServiceCollection services,
       IConfiguration configuration) =>
        services.AddSqlServer<RepositoryContext>(configuration.GetConnectionString("sqlConnection"));

    public static void ConfigureResponseCaching(this IServiceCollection services) =>
        services.AddResponseCaching();
    public static void ConfigureHttpCacheHeaders(this IServiceCollection services) =>
       services.AddHttpCacheHeaders(
        (expirationOpt) =>
        {
            expirationOpt.MaxAge = 65;
            expirationOpt.CacheLocation = CacheLocation.Private;

        },
        (validationOpt) =>
        {
            validationOpt.MustRevalidate = true;
        }
       );
    public static void ConfigureRateLimitingOptions(this IServiceCollection services)
    {

        var rateLimitRules = new List<RateLimitRule>{
        new RateLimitRule
        {
            Endpoint = "*",
            Limit = 50,
            Period = "5m"
        }

    };
        services.Configure<IpRateLimitOptions>(opt =>
        {
            opt.GeneralRules = rateLimitRules;

        });
        services.AddSingleton<IRateLimitCounterStore,
        MemoryCacheRateLimitCounterStore>();
        services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();

    }

    public static void ConfigureIdentity(this IServiceCollection services)
    {
        var builder = services.AddIdentity<User, IdentityRole>(o =>
        {
            o.Password.RequireDigit = true;
            o.Password.RequireLowercase = true;
            o.Password.RequireUppercase = true;
            o.Password.RequireNonAlphanumeric = true;
            o.Password.RequiredLength = 8;
            o.User.RequireUniqueEmail = true;

        })
        .AddEntityFrameworkStores<RepositoryContext>()
        .AddDefaultTokenProviders();
    }

    public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtConfiguration = new JwtConfiguration();
        configuration.Bind(jwtConfiguration.Section, jwtConfiguration);
        var secretKey = jwtConfiguration.Secret;


        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtConfiguration.ValidIssuer,
        ValidAudience = jwtConfiguration.ValidAudience,
        IssuerSigningKey = new
    SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});
    }
}