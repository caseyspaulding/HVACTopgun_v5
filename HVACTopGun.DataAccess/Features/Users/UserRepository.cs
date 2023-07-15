
using HVACTopGun.DataAccess.DataAccess;
using HVACTopGun.Domain.Features.Users;
using Microsoft.Data.SqlClient;

namespace HVACTopGun.DataAccess.Features.Users;

public class UserRepository : IUserRepository
{
    private readonly ISqlDataAccess _dataAccess;


    public UserRepository(ISqlDataAccess dataAccess)
    {
        _dataAccess = dataAccess;

    }

    public async Task CreateUser(UserModel user)
    {

        try
        {
            await _dataAccess.SaveData("dbo.spAddUser", new
            {
                user.UserId,
                user.TenantID,
                user.UserName,
                user.Email,
                user.FirstName,
                user.LastName,
                user.PhoneNumber,
                user.Deleted,
                user.DateDeleted,
                user.Role,
                user.AzureAD_ObjectID
            });
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Error occurred while creating user: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while creating user: {ex.Message}");
            throw;
        }
    }
    public async Task<UserModel> GetUserByObjectId(string objectId)
    {
        try
        {
            var results = await _dataAccess.LoadData<UserModel, dynamic>("dbo.spGetUserByObjectId", new { AzureAD_ObjectID = objectId });
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
    public async Task<int?> GetUserIdByObjectId(string azureObjectId)
    {
        try
        {
            var results = await _dataAccess.LoadData<UserModel, dynamic>("dbo.spGetUserByObjectId", new { AzureAD_ObjectID = azureObjectId });
            var user = results.FirstOrDefault();
            return user?.UserId;
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

    public async Task UpdateUser(UserModel user)
    {
        try
        {
            await _dataAccess.SaveData("dbo.spUpdateUser", new
            {
                user.UserId,
                user.TenantID,
                user.UserName,
                user.Email,
                user.FirstName,
                user.LastName,
                user.PhoneNumber,
                user.Deleted,
                user.DateDeleted,
                user.Role,
                user.AzureAD_ObjectID

            });
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Error occurred while updating user: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while updating user: {ex.Message}");
            throw;
        }
    }

    public async Task<bool> UserExists(string azureAD_ObjectID)
    {
        var userExists = await _dataAccess.LoadData<int, dynamic>("spUserExists", new { AzureAD_ObjectID = azureAD_ObjectID });

        return userExists.FirstOrDefault() > 0;
    }

    public async Task DeleteUser(int id)
    {
        try
        {
            await _dataAccess.SaveData("dbo.spSoftDeleteUser", new { Id = id });
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Error occurred while deleting user: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while deleting user: {ex.Message}");
            throw;
        }
    }
}

