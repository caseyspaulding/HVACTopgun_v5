namespace HVACTopGun.DataAccess.Features.ApiKeys;

public interface IApiKeyRepository
{
    Task AddApiKey(string apiKey, int tenantId);
    Task<bool> IsApiKeyValid(string apiKey);
    Task<bool> IsValidApiKeyAsync(string apiKey);
    Task RemoveApiKey(string apiKey);
}