using DataAccess.DbAccess;
using DataAccess.Models;
using System.Data.SqlClient;

namespace DataAccess.DataService
{
    public class AppointmentsDataService : IAppointmentsDataService
    {
        private readonly ISqlDataAccess _dataAccess;

        public AppointmentsDataService(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task CreateAppointment(AppointmentModel appointment)
        {
            try
            {
                await _dataAccess.SaveData("dbo.spAddAppointment", new
                {
                    appointment.AppointmentID,
                    appointment.TenantID,
                    appointment.UserID,
                    appointment.Subject,
                    appointment.Description,
                    appointment.StartTime,
                    appointment.EndTime,
                    appointment.TechnicianName,
                    appointment.CustomerName,
                    appointment.Location,
                    appointment.Status,
                    appointment.IsAllDay,
                    appointment.RecurrenceID,
                    appointment.RecurrenceRule,
                    appointment.RecurrenceException,
                    appointment.IsReadonly,
                    appointment.IsBlock,
                    appointment.CssClass,
                    appointment.AvailableAppointmentId,
                    appointment.TenantName,
                    appointment.CategoryColor,
                    appointment.StartTimeZone,
                    appointment.EndTimeZone,
                    appointment.CreatedAt,
                    appointment.UpdatedAt,
                    appointment.TechnicianId,
                    appointment.Technician,
                    appointment.CustomerId,
                    appointment.Customer,
                    appointment.ServiceID,
                    appointment.Deleted,
                    appointment.DateDeleted,
                    appointment.JobTypeId,
                    appointment.JobType


                });
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error occurred while creating user: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while creating user: {ex.Message}");
                throw;
            }
        }

        public async Task<AppointmentModel?> GetAppointmentById(int id)
        {
            try
            {
                var results = await _dataAccess.LoadData<AppointmentModel, dynamic>("dbo.spGetAppointmentById", new { Id = id });
                return results.FirstOrDefault();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error occurred while retrieving user: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while retrieving user: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateAppointment(AppointmentModel appointment)
        {
            try
            {
                await _dataAccess.SaveData("dbo.spUpdateAppointment", new
                {
                    appointment.AppointmentID,
                    appointment.TenantID,
                    appointment.UserID,
                    appointment.Subject,
                    appointment.Description,
                    appointment.StartTime,
                    appointment.EndTime,
                    appointment.TechnicianName,
                    appointment.CustomerName,
                    appointment.Location,
                    appointment.Status,
                    appointment.IsAllDay,
                    appointment.RecurrenceID,
                    appointment.RecurrenceRule,
                    appointment.RecurrenceException,
                    appointment.IsReadonly,
                    appointment.IsBlock,
                    appointment.CssClass,
                    appointment.AvailableAppointmentId,
                    appointment.TenantName,
                    appointment.CategoryColor,
                    appointment.StartTimeZone,
                    appointment.EndTimeZone,
                    appointment.CreatedAt,
                    appointment.UpdatedAt,
                    appointment.TechnicianId,
                    appointment.Technician,
                    appointment.CustomerId,
                    appointment.Customer,
                    appointment.ServiceID,
                    appointment.Deleted,
                    appointment.DateDeleted,
                    appointment.JobTypeId,
                    appointment.JobType

                });
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error occurred while updating appointment: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while updating appointment: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteAppointment(int id)
        {
            try
            {
                await _dataAccess.SaveData("dbo.spDeleteAppointment", new { Id = id });
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error occurred while deleting appointment: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while deleting appointment: {ex.Message}");
                throw;
            }
        }
    }
}
