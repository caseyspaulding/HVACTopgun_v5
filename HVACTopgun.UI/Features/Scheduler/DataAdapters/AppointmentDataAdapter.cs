using DataAccess.Data;
using DataAccess.DbAccess;
using DataAccess.Models;
using HVACTopGun.UI.Helpers;
using Microsoft.AspNetCore.Components.Authorization;
using Syncfusion.Blazor;


namespace HVACTopGun.UI.Features.Scheduler.DataAdapters
{
    public class AppointmentsDataAdapter : DataAdaptor
    {
        private readonly ISqlDataAccess _dataAccess;
        private readonly ITenantDataService _tenantDataService;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AppointmentsDataAdapter(ISqlDataAccess dataAccess, ITenantDataService tenantDataService, AuthenticationStateProvider authenticationStateProvider)
        {
            _dataAccess = dataAccess;
            _tenantDataService = tenantDataService;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
            var tenantId = await _authenticationStateProvider.GetTenantIdFromAuth(_tenantDataService);

            if (tenantId != null)
            {
                var storedProcedure = "spGetAllAppointmentModels";
                var appointments = await _dataAccess.LoadData<AppointmentModel, dynamic>(storedProcedure, new { TenantID = tenantId });

                return appointments;
            }

            return Enumerable.Empty<AppointmentModel>();
        }

        public override async Task<object> InsertAsync(DataManager dataManager, object data, string key)
        {
            var appointment = data as AppointmentModel;
            var tenantId = await _authenticationStateProvider.GetTenantIdFromAuth(_tenantDataService);

            if (tenantId != null)
            {
                var storedProcedure = $"spAddAppointmentModel";
                await _dataAccess.SaveData(storedProcedure, new
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
                    appointment.DateDeleted,
                    appointment.JobTypeId
                    //... Add all the necessary properties of the appointment.
                });
            }

            return Task.CompletedTask;
        }

        public override async Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
        {
            var appointment = data as AppointmentModel;
            var tenantId = await _authenticationStateProvider.GetTenantIdFromAuth(_tenantDataService);

            if (tenantId != null)
            {
                var storedProcedure = $"spUpdateAppointmentModel";
                await _dataAccess.SaveData(storedProcedure, new
                {
                    appointment.Id,
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
                    UpdatedAt = DateTime.UtcNow,
                    appointment.TechnicianId,
                    appointment.CustomerId,
                    appointment.ServiceId,
                    appointment.Deleted,
                    appointment.DateDeleted,
                    appointment.JobTypeId
                    //... Add all the necessary properties of the appointment.
                });
            }

            return data;
        }

        public override async Task<object> RemoveAsync(DataManager dataManager, object primaryKeyValue, string keyField, string key)
        {
            var appointmentId = (int)primaryKeyValue;
            var tenantId = await _authenticationStateProvider.GetTenantIdFromAuth(_tenantDataService);

            if (tenantId != null)
            {
                var storedProcedure = $"dbo.spSoftDeleteAppointmentModel";
                await _dataAccess.SaveData(storedProcedure, new { AppointmentId = appointmentId, TenantId = tenantId });
            }

            return primaryKeyValue;
        }
    }
}