using DataAccess.Models;
using HVACTopGun.UI.Features.Scheduler.DataAdapters;
using HVACTopGun.UI.Features.Scheduler.Models;

namespace HVACTopGun.UI.Features.Scheduler.Services
{
    public class AppointmentsUIService
    {
        private readonly AppointmentsDataAdapter _appointmentsDataAdapter;

        public AppointmentsUIService(AppointmentsDataAdapter appointmentsDataAdapter)
        {
            _appointmentsDataAdapter = appointmentsDataAdapter;
        }

        public async Task<List<AppointmentModel>> GetAllAppointments()
        {
            // Use the data adapter to fetch appointments
            var appointments = await _appointmentsDataAdapter.ReadAsync(dataManagerRequest: null);
            return (List<AppointmentModel>)appointments;
        }

        public async Task CreateAppointment(UIAppointmentModel uiAppointment)
        {
            // Map the UI appointment to the data access appointment model
            var appointment = MapToDataAccessAppointment(uiAppointment);

            // Use the data adapter to insert the appointment
            await _appointmentsDataAdapter.InsertAsync(dataManager: null, data: appointment, key: null);
        }

        public async Task UpdateAppointment(UIAppointmentModel uiAppointment)
        {
            // Map the UI appointment to the data access appointment model
            var appointment = MapToDataAccessAppointment(uiAppointment);

            // Use the data adapter to update the appointment
            await _appointmentsDataAdapter.UpdateAsync(dataManager: null, data: appointment, keyField: null, key: null);
        }

        public async Task DeleteAppointment(int appointmentId)
        {
            // Use the data adapter to remove the appointment
            await _appointmentsDataAdapter.RemoveAsync(dataManager: null, primaryKeyValue: appointmentId, keyField: null, key: null);
        }

        private AppointmentModel MapToDataAccessAppointment(UIAppointmentModel uiAppointment)
        {
            // Perform the mapping between the UI appointment and the data access appointment model
            // You can use AutoMapper or manual mapping depending on your preference

            AppointmentModel dataAccessAppointment = new AppointmentModel
            {
                // Map the properties accordingly
            };

            return dataAccessAppointment;
        }
    }
}
