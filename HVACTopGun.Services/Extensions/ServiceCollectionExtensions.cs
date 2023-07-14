using HVACTopGun.DataAccess.Features.Appointments;
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
        // Other application layer services and implementations...
    }

    private static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }

    private static void AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }


}
