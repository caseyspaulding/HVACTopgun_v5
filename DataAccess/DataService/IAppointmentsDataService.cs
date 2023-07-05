using DataAccess.Models;

namespace DataAccess.DataService
{
    public interface IAppointmentsDataService
    {
        Task CreateAppointment(AppointmentModel appointment, int tenantId);
        Task DeleteAppointment(int appointmentId, int tenantId);
        Task<AppointmentModel?> GetAppointmentById(int id, int tenantId);
        Task UpdateAppointment(AppointmentModel appointment, int tenantId);
    }
}