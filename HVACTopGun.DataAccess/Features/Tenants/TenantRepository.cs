using HVACTopGun.DataAccess.DataAccess;
using HVACTopGun.Domain.Features.Tenants;
using HVACTopGun.Domain.Features.Users;
using Microsoft.Data.SqlClient;

namespace HVACTopGun.DataAccess.Features.Tenants;

public class TenantRepository : ITenantRepository
{
    private readonly ISqlDataAccess _dataAccess;

    public TenantRepository(ISqlDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public async Task<int?> GetTenantIdByObjectId(string objectId)
    {
        var parameters = new { ObjectId = objectId };
        var result = await _dataAccess.LoadData<int?, dynamic>("spGetTenantIdByObjectId", parameters);
        return result.FirstOrDefault();
    }



    public async Task<int> GetLastCreatedTenantId()
    {
        try
        {
            var result = await _dataAccess.LoadData<TenantModel, dynamic>("dbo.spGetAllTenants", new { });
            var lastTenant = result.OrderByDescending(t => t.TenantID).FirstOrDefault();

            if (lastTenant == null)
            {
                throw new Exception("No tenants found in the database.");
            }

            return lastTenant.TenantID;
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Error occurred while retrieving last created TenantID: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while retrieving last created TenantID: {ex.Message}");
            throw;
        }
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
    public async Task<TenantModel?> GetTenantByBusinessName(string businessName)
    {
        try
        {
            var results = await _dataAccess.LoadData<TenantModel, dynamic>("dbo.spGetTenantByBusinessName", new { CompanyName = businessName });
            return results.FirstOrDefault();
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Error occurred while retrieving tenant: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while retrieving tenant: {ex.Message}");
            throw;
        }
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
                                   tenant.PaymentStatus,
                                   tenant.TrialExpirationDate
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
    public async Task<UserModel?> GetUserById(int id)
    {
        try
        {
            var results = await _dataAccess.LoadData<UserModel, dynamic>("dbo.spGetUserById", new { Id = id });
            return results.FirstOrDefault();
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Error occurred while retrieving user: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while retrieving user: {ex.Message}");
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




