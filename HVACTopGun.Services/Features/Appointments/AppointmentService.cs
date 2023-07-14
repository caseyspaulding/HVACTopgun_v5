using HVACTopGun.Domain.Features.Appointments;

namespace HVACTopGun.DataAccess.Features.Appointments
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentsRepository _appointmentDataService;

        public AppointmentService(IAppointmentsRepository appointmentDataService)
        {
            _appointmentDataService = appointmentDataService;
        }

        public async Task<List<AppointmentModel>> GetAllAppointments(int tenantId)
        {
            return await _appointmentDataService.GetAllAppointments(tenantId);
        }

        public async Task CreateAppointment(AppointmentModel appointment, int tenantId, int userId)
        {
            await _appointmentDataService.CreateAppointment(appointment, tenantId, userId);
        }

        public async Task UpdateAppointment(AppointmentModel appointment, int tenantId)
        {
            await _appointmentDataService.UpdateAppointment(appointment, tenantId);
        }

        public async Task DeleteAppointment(int appointmentId, int tenantId)
        {
            await _appointmentDataService.DeleteAppointment(appointmentId, tenantId);
        }
    }
}
