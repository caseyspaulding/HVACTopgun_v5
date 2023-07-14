using HVACTopGun.Domain.Features.Tenants;
using HVACTopGun.Domain.Features.Users;

namespace HVACTopGun.DataAccess.Features.Tenants;
public interface ITenantRepository
{
    Task CreateTenant(TenantModel tenant);
    Task DeleteTenant(int id);
    Task<IEnumerable<TenantModel>> GetAllTenants();
    Task<int> GetLastCreatedTenantId();
    Task<TenantModel?> GetTenant(int id);
    Task<TenantModel?> GetTenantByBusinessName(string businessName);
    Task<int?> GetTenantIdByObjectId(string objectId);
    Task<UserModel?> GetUserById(int id);
}