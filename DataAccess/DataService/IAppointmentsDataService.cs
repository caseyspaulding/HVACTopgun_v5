using DataAccess.Models;

namespace DataAccess.DataService
{
    public interface IAppointmentsDataService
    {
        Task CreateAppointment(AppointmentModel appointment);
        Task DeleteAppointment(int id);
        Task<AppointmentModel?> GetAppointmentById(int id);
        Task UpdateAppointment(AppointmentModel appointment);
    }
}