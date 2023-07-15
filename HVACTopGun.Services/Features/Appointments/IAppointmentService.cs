using HVACTopGun.Domain.Features.Appointments;

namespace HVACTopGun.Services.Features.Appointments;
public interface IAppointmentService
{
    Task CreateAppointment(AppointmentModel appointment, int tenantId, int userId);
    Task DeleteAppointment(int appointmentId, int tenantId);
    Task<List<AppointmentModel>> GetAllAppointments(int tenantId);
    Task UpdateAppointment(AppointmentModel appointment, int tenantId);
}