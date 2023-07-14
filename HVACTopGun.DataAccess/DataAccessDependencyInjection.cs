using HVACTopGun.DataAccess.DataAccess;
using HVACTopGun.DataAccess.Features.Appointments;
using HVACTopGun.DataAccess.Features.Tenants;
using HVACTopGun.DataAccess.Features.Users;
using HVACTopGun.Domain.Features.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace HVACTopGun.DataAccess;
public static class DataAccessDependencyInjection
{
    public static void RegisterDataAccessServices(IServiceCollection services)
    {
        // Register DataAccess services and implementations
        services.AddScoped<ISqlDataAccess, SqlDataAccess>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAppointmentsRepository, AppointmentsRepository>();
        services.AddScoped<ITenantRepository, TenantRepository>();
        services.AddScoped<IRoleRepository>();
        services.AddScoped<AuthClaimsModel>();
        // Other DataAccess services and implementations...

        // Optionally, you can register other dependencies that the DataAccess layer may require
        // services.AddScoped<IDataAccessDependency, DataAccessDependency>();
    }
}