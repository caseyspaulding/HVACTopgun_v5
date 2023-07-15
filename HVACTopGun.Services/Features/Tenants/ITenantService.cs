using HVACTopGun.Services.Features.Users;

namespace HVACTopGun.Services.Features.Tenants;
public interface ITenantService
{
    Task CreateTenant(TenantDto tenantDto);
    Task DeleteTenant(int id);
    Task<IEnumerable<TenantDto>> GetAllTenants();
    Task<int> GetLastCreatedTenantId();
    Task<TenantDto?> GetTenant(int id);
    Task<TenantDto?> GetTenantByBusinessName(string businessName);
    Task<int?> GetTenantIdByObjectId(string objectId);
    Task<UserDto?> GetUserById(int id);
}