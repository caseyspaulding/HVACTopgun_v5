using HVACTopGun.DataAccess.DataAccess;
using HVACTopGun.DataAccess.Features.Appointments;
using HVACTopGun.DataAccess.Features.Roles;
using HVACTopGun.DataAccess.Features.Tenants;
using HVACTopGun.DataAccess.Features.Users;
using Microsoft.Extensions.DependencyInjection;

namespace HVACTopGun.DataAccess
{
    public static class DataAccessSetup
    {
        public static void AddDataAccessServices(IServiceCollection services)
        {
            // Register DataAccess services here
            services.AddScoped<ISqlDataAccess, SqlDataAccess>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAppointmentsRepository, AppointmentsRepository>();
            services.AddScoped<ITenantRepository, TenantRepository>();

            // Register domain services here
            services.AddScoped<IRoleRepository, RoleRepository>();

            // Other DataAccess services...


        }
    }
}