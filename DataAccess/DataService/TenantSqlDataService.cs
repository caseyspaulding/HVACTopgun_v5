using DataAccess.DbAccess;
using DataAccess.Models;
using DataAccess.Models.Interfaces;

namespace DataAccess.Data;

public class TenantSqlDataService : ITenantSqlDataService
{
    private readonly ISqlDataAccess _dataAccess;

    public TenantSqlDataService(ISqlDataAccess dataAccess)
    {
        this._dataAccess = dataAccess;
    }

    public Task<IEnumerable<TenantModel>> GetAllTenant()
    {
        return _dataAccess.LoadData<TenantModel, dynamic>("dbo.getAllTenants", new { });
    }

    public async Task<TenantModel?> GetTenant(int id)
    {
        var results = await _dataAccess.LoadData<TenantModel, dynamic>(
            "dbo.getTenant",
            new { Id = id });
        return results.FirstOrDefault();
    }

    // insert, update, delete
    public Task CreateTenant(ITenantModel customer) => _dataAccess.SaveData("dbo.addTenant",
        new { customer.FirstName, customer.LastName });

    public Task UpdateTenant(TenantModel customer) =>
        _dataAccess.SaveData("dbo.updateTenant", customer);

    public Task DeleteTenant(int id) =>
        _dataAccess.SaveData("dbo.deleteTenant", new { Id = id });

    public Task<TenantModel> GetUserFromAuthentication(string objectId)
    {
        throw new NotImplementedException();
    }
}