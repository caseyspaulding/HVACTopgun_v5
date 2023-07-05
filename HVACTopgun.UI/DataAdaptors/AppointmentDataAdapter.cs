using DataAccess.Data;
using DataAccess.DbAccess;
using DataAccess.Models;
using HVACTopGun.UI.Helpers;
using Microsoft.AspNetCore.Components.Authorization;
using Syncfusion.Blazor;

namespace HVACTopGun.UI.DataAdaptors
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
                var storedProcedure = $"spGetAllAppointmentModels";
                var appointments = await _dataAccess.LoadData<AppointmentModel, dynamic>(storedProcedure, new { TenantID = tenantId });

                return appointments;
            }

            // Return an empty list or handle the absence of a valid tenant ID as needed
            return new List<AppointmentModel>();
        }

        public override async Task<object> InsertAsync(DataManager dataManager, object data, string key)
        {
            var appointment = data as AppointmentModel;

            var storedProcedure = $"spAddAppointmentModel";
            await _dataAccess.SaveData(storedProcedure, appointment);

            return data;
        }

        public override async Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
        {
            var appointment = data as AppointmentModel;

            var storedProcedure = $"spUpdateAppointmentModel";
            await _dataAccess.SaveData(storedProcedure, appointment);

            return data;
        }

        public override async Task<object> RemoveAsync(DataManager dataManager, object primaryKeyValue, string keyField, string key)
        {
            var appointmentId = (int)primaryKeyValue;
            var tenantId = await _authenticationStateProvider.GetTenantIdFromAuth(_tenantDataService);

            var storedProcedure = $"dbo.spSoftDeleteAppointmentModel";
            await _dataAccess.SaveData(storedProcedure, new { AppointmentID = appointmentId, TenantID = tenantId });

            return primaryKeyValue;
        }
    }
}
