using DataAccess.DbAccess;
using DataAccess.Models;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace DataAccess.DataService
{
    public class AppointmentsDataService : IAppointmentsDataService
    {
        private readonly ISqlDataAccess _dataAccess;

        public AppointmentsDataService(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task CreateAppointment(AppointmentModel appointment, int tenantId, int? userId)
        {
            {

                try
                {
                    Console.WriteLine(appointment.StartTime.GetType());
                    Console.WriteLine($"StartTime: {appointment.StartTime}, EndTime: {appointment.EndTime}");
                    int newAppointmentId = await _dataAccess.InsertDataReturnId("dbo.spAddAppointmentModel", new
                    {

                        TenantId = tenantId,
                        UserId = userId,
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
                        appointment.TechnicianId,
                        appointment.CustomerId,
                        appointment.ServiceId,
                        appointment.Deleted,

                        appointment.JobTypeId


                    });
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Error occurred while creating appointment: {ex.Message}");
                    Console.WriteLine($"Appointment data: {JsonConvert.SerializeObject(appointment)}");

                    Console.WriteLine($"StartTime: {appointment.StartTime}, EndTime: {appointment.EndTime}");
                    Console.WriteLine($"CreatedAt: {appointment.CreatedAt}, UpdatedAt: {appointment.UpdatedAt}, DateDeleted: {appointment.DateDeleted}");

                    Console.WriteLine($"Error occurred while creating user: {ex.Message}");
                    Console.WriteLine($"CreatedAt: {appointment.CreatedAt}, UpdatedAt: {appointment.UpdatedAt}, DateDeleted: {appointment.DateDeleted}");
                    throw;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"StartTime: {appointment.StartTime}, EndTime: {appointment.EndTime}");
                    Console.WriteLine($"CreatedAt: {appointment.CreatedAt}, UpdatedAt: {appointment.UpdatedAt}, DateDeleted: {appointment.DateDeleted}");

                    Console.WriteLine($"Error occurred while creating user: {ex.Message}");

                    Console.WriteLine($"CreatedAt: {appointment.CreatedAt}, UpdatedAt: {appointment.UpdatedAt}, DateDeleted: {appointment.DateDeleted}");
                    throw;
                }
            }
        }
        public async Task<List<AppointmentModel>> GetAllAppointments(int tenantId)
        {
            try
            {
                var results = await _dataAccess.LoadData<AppointmentModel, dynamic>("dbo.spGetAllAppointmentModels", new { TenantId = tenantId });
                // Log the results
                Console.WriteLine(JsonConvert.SerializeObject(results));
                return results.ToList();

            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error occurred while retrieving appointments: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while retrieving appointments: {ex.Message}");
                throw;
            }
        }
        public async Task<AppointmentModel?> GetAppointmentById(int id, int tenantId)
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

        public async Task UpdateAppointment(AppointmentModel appointment, int tenantId)
        {
            try
            {
                await _dataAccess.SaveData("dbo.spUpdateAppointmentModel", new
                {
                    TenantId = tenantId,
                    appointment.UserId,
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
                    appointment.CustomerId,
                    appointment.ServiceId,
                    appointment.Deleted,

                    appointment.JobTypeId
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

        public async Task DeleteAppointment(int appointmentId, int tenantId)
        {
            try
            {
                await _dataAccess.SaveData("dbo.spSoftDeleteAppointmentModel", new { Id = appointmentId, TenantID = tenantId });
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
