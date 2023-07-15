using HVACTopGun.Services.Features.Appointments;
using HVACTopGun.Services.Features.Auth;
using HVACTopGun.Services.Features.Users;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HVACTopGun.Services.Extensions;

public static class ServiceCollectionExtensions
{

    public static void AddServicesLayer(this IServiceCollection services)
    {

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        // Register application layer services and implementations
        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddScoped<IUserService, UserService>();

        services.AddScoped<IAuthService, AuthService>();
        // Add additional application layer services and implementations...

        // For example:
        // services.AddScoped<IAnotherService, AnotherService>();

        // Other application layer services and implementations...
    }




}
