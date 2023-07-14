using AutoMapper;
using HVACTopGun.Application.Features.Tenants;
using HVACTopGun.Application.Features.Users;
using HVACTopGun.Domain.Features.Tenants;
using HVACTopGun.Domain.Features.Users;

namespace HVACTopGun.Application.Common.Mappings;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<TenantDto, TenantModel>();
        CreateMap<TenantModel, TenantDto>();
        CreateMap<UserDto, UserModel>();
        CreateMap<UserModel, UserDto>();



        // Add other mappings as needed...
    }
}