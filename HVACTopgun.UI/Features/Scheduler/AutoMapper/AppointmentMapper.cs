using AutoMapper;
using HVACTopGun.Domain.Features.Appointments;
using HVACTopGun.UI.Features.Scheduler.Models;

namespace HVACTopGun.UI.Features.Scheduler.AutoMapper
{
    public class AppointmentMapper : Profile
    {
        public AppointmentMapper()
        {
            CreateMap<UIAppointmentModel, AppointmentModel>().ReverseMap();
        }
    }
}
