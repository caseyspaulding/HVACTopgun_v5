using HVACTopGun.DataAccess.DataAccess;
using Microsoft.Data.SqlClient;

namespace HVACTopGun.DataAccess.Features.ApiKeys
{
    public class ApiKeyRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public ApiKeyRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task AddApiKey(string apiKey, int tenantId)
        {
            try
            {
                await _dataAccess.SaveData("dbo.spAddApiKey", new { ApiKey = apiKey, TenantId = tenantId });
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error occurred while adding API key: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> IsApiKeyValid(string apiKey)
        {
            try
            {
                var results = await _dataAccess.LoadData<int, dynamic>("dbo.spIsApiKeyValid", new { ApiKey = apiKey });
                return results.FirstOrDefault() > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error occurred while validating API key: {ex.Message}");
                throw;
            }
        }

        public async Task RemoveApiKey(string apiKey)
        {
            try
            {
                await _dataAccess.SaveData("dbo.spRemoveApiKey", new { ApiKey = apiKey });
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error occurred while removing API key: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> IsValidApiKeyAsync(string apiKey)
        {
            var sql = "SELECT COUNT(1) FROM ApiKeys WHERE Key = @Key AND IsValid = 1";
            // Assume you have a table named "ApiKeys" and a column "IsValid" that indicates if the key is active

            var count = await _dataAccess.LoadData<int, dynamic>(sql, new { Key = apiKey });

            return count.FirstOrDefault() == 1;
        }
    }
}