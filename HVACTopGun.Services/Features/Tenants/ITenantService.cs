using HVACTopGun.Domain.Features.Users;

namespace HVACTopGun.Application.Features.Tenants;
public interface ITenantService
{
    Task CreateTenant(TenantDto tenantDto);
    Task DeleteTenant(int id);
    Task<IEnumerable<TenantDto>> GetAllTenants();
    Task<int> GetLastCreatedTenantId();
    Task<TenantDto?> GetTenant(int id);
    Task<TenantDto?> GetTenantByBusinessName(string businessName);
    Task<int?> GetTenantIdByObjectId(string objectId);
    Task<UserModel?> GetUserById(int id);
}