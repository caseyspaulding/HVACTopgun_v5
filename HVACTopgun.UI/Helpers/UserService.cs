using DataAccess.DbAccess;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace HVACTopGun.UI.Helpers
{
    public class UserService
    {
        private readonly ISqlDataAccess _dbAccess;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public UserService(ISqlDataAccess dbAccess, AuthenticationStateProvider authenticationStateProvider)
        {
            _dbAccess = dbAccess;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task CreateUserAndTenant()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            var azureAD_ObjectID = user.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value;
            var userName = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var businessName = user.Claims.FirstOrDefault(c => c.Type == "businessName")?.Value;

            if (azureAD_ObjectID == null || userName == null || businessName == null)
            {
                throw new Exception("Unable to retrieve necessary claim values for user creation");
            }

            var userExists = await UserExists(azureAD_ObjectID);
            if (!userExists)
            {
                // Tenant insert parameters
                var tenantParameters = new
                {
                    FirstName = "First Name",
                    LastName = "Last Name",
                    CompanyName = businessName,
                    Domain = "Domain",
                    Email = "Email",
                    PhoneNumber = "Phone Number",
                    Address = "Address",
                    City = "City",
                    State = "State",
                    Zipcode = "Zipcode",
                    TimeZone = "TimeZone",
                    SubscriptionType = 1,
                    PaymentStatus = 1
                };

                var tenantId = (await _dbAccess.LoadData<int, dynamic>("spInsertTenant", tenantParameters)).Single();

                // User insert parameters
                var userParameters = new
                {
                    TenantID = tenantId,
                    AzureAD_ObjectID = azureAD_ObjectID,
                    Role = "Role",
                    UserName = userName,
                    Email = "Email",
                    FirstName = "First Name",
                    LastName = "Last Name",
                    PhoneNumber = "Phone Number"
                };

                await _dbAccess.SaveData("spInsertUser", userParameters);
            }
        }

        public async Task<bool> UserExists(string azureAD_ObjectID)
        {
            var userExists = await _dbAccess.LoadData<int, dynamic>("spUserExists", new { AzureAD_ObjectID = azureAD_ObjectID });

            return userExists.FirstOrDefault() > 0;
        }
    }
}