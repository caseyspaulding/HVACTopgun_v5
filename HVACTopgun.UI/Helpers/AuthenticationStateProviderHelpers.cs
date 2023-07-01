using DataAccess.Models;
using Microsoft.AspNetCore.Components.Authorization;

namespace HVACTopGun.UI.Helpers
{
    public static class AuthenticationStateProviderHelpers
    {
        public static async Task<TenantModel> GetTenantFromAuth(
            this AuthenticationStateProvider provider,
            ITenantDataService tenantSqlData)
        {
            var authState = await provider.GetAuthenticationStateAsync();
            string objectId = authState.User.Claims.FirstOrDefault(c => c.Type.Contains("objectidentifier"))?.Value;

            if (string.IsNullOrEmpty(objectId))
            {
                throw new InvalidOperationException("Unable to find ObjectIdentifier claim.");
            }

            var tenant = await tenantSqlData.GetTenantFromAuthentication(objectId);

            if (tenant == null)
            {
                throw new InvalidOperationException($"Unable to find tenant for ObjectIdentifier: {objectId}");
            }

            return tenant;
        }
    }
}