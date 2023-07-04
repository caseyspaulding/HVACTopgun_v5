using DataAccess.Models;

namespace DataAccess.Data
{
    public interface ITenantDataService
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
}