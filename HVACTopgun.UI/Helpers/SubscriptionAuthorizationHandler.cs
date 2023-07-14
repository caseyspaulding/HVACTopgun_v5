// SubscriptionAuthorizationHandler.cs

using HVACTopGun.DataAccess.Features.Tenants;
using Microsoft.AspNetCore.Authorization;
namespace HVACTopGun.UI.Helpers
{
    public class SubscriptionAuthorizationHandler : AuthorizationHandler<SubscriptionRequirement>
    {
        private readonly ITenantRepository _tenantDataService;

        public SubscriptionAuthorizationHandler(ITenantRepository tenantDataService)
        {
            _tenantDataService = tenantDataService;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, SubscriptionRequirement requirement)
        {
            var tenantIdClaim = context.User.Claims.FirstOrDefault(c => c.Type == "TenantId");
            if (tenantIdClaim == null)
            {
                // If the user does not have a tenant claim, do not satisfy the requirement
                return;
            }

            var tenantId = int.Parse(tenantIdClaim.Value);
            var tenant = await _tenantDataService.GetTenant(tenantId);
            if (tenant == null)
            {
                // If the tenant does not exist, do not satisfy the requirement
                return;
            }

            bool isTrialStillValid = tenant.TrialExpirationDate > DateTime.Now;

            if ((tenant.SubscriptionType == "Trial" && isTrialStillValid) ||
                tenant.SubscriptionType == "Basic" ||
                tenant.SubscriptionType == "Premium")
            {
                // If the tenant has a valid trial, basic, or premium subscription, satisfy the requirement
                context.Succeed(requirement);
            }
        }
    }

    public class SubscriptionRequirement : IAuthorizationRequirement { }
}
