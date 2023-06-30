using DataAccess.Models;
using DataAccess.Models.Interfaces;

namespace DataAccess.Data
{
    public interface ITenantSqlDataService
    {
        Task CreateTenant(ITenantModel customer);
        Task DeleteTenant(int id);
        Task<IEnumerable<TenantModel>> GetAllTenant();
        Task<TenantModel?> GetTenant(int id);
        Task<TenantModel> GetUserFromAuthentication(string objectId);
        Task UpdateTenant(TenantModel customer);
    }
}