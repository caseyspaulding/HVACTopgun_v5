using HVACTopGun.Domain.Features.Auth;
using HVACTopGun.Services.Common.Mappings;
using HVACTopGun.Services.Features.Auth;
using HVACTopGun.Services.Features.Tenants;
using HVACTopGun.Services.Features.Users;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace HVACTopGun.Services;
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITenantService, TenantService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<AuthClaimsModel>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        // Configure AutoMapper
        services.AddAutoMapper(typeof(MappingProfile).Assembly);


        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());


            config.AddOpenBehavior(typeof(RequestExceptionProcessorBehavior<,>));
        }
    );


        return services;
    }
}



