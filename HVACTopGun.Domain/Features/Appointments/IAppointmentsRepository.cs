using HVACTopGun.Domain.Features.Appointments;

namespace HVACTopGun.DataAccess.Features.Appointments;
public interface IAppointmentsRepository
{
    Task CreateAppointment(AppointmentModel appointment, int tenantId, int? userId);
    Task DeleteAppointment(int appointmentId, int tenantId);
    Task<List<AppointmentModel>> GetAllAppointments(int tenantId);
    Task<AppointmentModel?> GetAppointmentById(int id, int tenantId);
    Task UpdateAppointment(AppointmentModel appointment, int tenantId);
}