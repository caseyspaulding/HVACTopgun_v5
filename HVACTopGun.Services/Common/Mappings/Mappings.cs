using AutoMapper;
using HVACTopGun.Domain.Features.Tenants;
using HVACTopGun.Domain.Features.Users;
using HVACTopGun.Services.Features.Tenants;
using HVACTopGun.Services.Features.Users;

namespace HVACTopGun.Services.Common.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserDto, UserModel>();
        CreateMap<UserModel, UserDto>();
        CreateMap<TenantDto, TenantModel>();
        CreateMap<TenantModel, TenantDto>();

        // Add more mappings as needed
    }
}
