using DataAccess.Data;
using DataAccess.Models;
using Microsoft.AspNetCore.Components.Authorization;

namespace HVACTopGun.UI.Helpers
{
    public static class AuthenticationStateProviderHelpers
    {
        public static async Task<TenantModel> GetTenantFromAuth(
            this AuthenticationStateProvider provider,
            ITenantSqlDataService tenantSqlData)
        {
            var authState = await provider.GetAuthenticationStateAsync();
            string objectId = authState.User.Claims.FirstOrDefault(c => c.Type.Contains("objectidentifier"))?.Value;
            return await tenantSqlData.GetUserFromAuthentication(objectId);
        }
    }

}
