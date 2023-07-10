using AutoMapper;
using DataAccess.Models;
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
