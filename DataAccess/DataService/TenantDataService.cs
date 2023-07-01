using DataAccess.DbAccess;
using DataAccess.Models;
using System.Data.SqlClient;

namespace DataAccess.Data;

public class TenantDataService
{
    private readonly ISqlDataAccess _dataAccess;

    public TenantDataService(ISqlDataAccess dataAccess)
    {
        this._dataAccess = dataAccess;
    }

    public Task<IEnumerable<TenantModel>> GetAllTenants()
    {
        return _dataAccess.LoadData<TenantModel, dynamic>("dbo.spGetAllTenants", new { });
    }

    public async Task<TenantModel?> GetTenant(int id)
    {
        var results = await _dataAccess.LoadData<TenantModel, dynamic>(
            "dbo.spGetTenant",
            new { Id = id });
        return results.FirstOrDefault();
    }

    // insert, update, delete
    public async Task CreateTenant(TenantModel tenant)
    {
        try
        {
            await _dataAccess.SaveData("dbo.spAddTenant",
                               new
                               {
                                   tenant.FirstName,
                                   tenant.LastName,
                                   tenant.CompanyName,
                                   tenant.Domain,
                                   tenant.Email,
                                   tenant.PhoneNumber,
                                   tenant.Address,
                                   tenant.City,
                                   tenant.State,
                                   tenant.ZipCode,
                                   tenant.TimeZone,
                                   tenant.IsActive,
                                   tenant.Deleted,
                                   tenant.SubscriptionType,
                                   tenant.PaymentStatus
                               });
        }
        catch (SqlException ex)
        {
            // Handle specific SQL exceptions, such as constraint violations or connection errors
            Console.WriteLine($"Error occurred while creating tenant: {ex.Message}");
            // You can also throw a custom exception or log the error for further analysis
            throw;
        }
        catch (Exception ex)
        {
            // Handle other exceptions
            Console.WriteLine($"Error occurred while creating tenant: {ex.Message}");
            throw;
        }

    }

    public async Task DeleteTenant(int id)
    {
        try
        {
            await _dataAccess.SaveData("dbo.spSoftDeleteTenant", new { Id = id });
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Error occurred while deleting tenant: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while deleting tenant: {ex.Message}");
            throw;
        }
    }
}




