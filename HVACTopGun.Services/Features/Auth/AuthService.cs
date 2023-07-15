using HVACTopGun.DataAccess.Features.Tenants;
using HVACTopGun.DataAccess.Features.Users;
using HVACTopGun.Domain.Features.Auth;
using HVACTopGun.Domain.Features.Tenants;
using HVACTopGun.Domain.Features.Users;

namespace HVACTopGun.Services.Features.Auth
{
    public class AuthService : IAuthService
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public AuthService(ITenantRepository tenantRepository, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _tenantRepository = tenantRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task ProcessUserAsync(AuthClaimsModel authClaims)
        {
            var user = await _userRepository.GetUserByObjectId(authClaims.ObjectId);

            if (user == null)
            {
                var tenant = new TenantModel
                {
                    FirstName = authClaims.FirstName,
                    LastName = authClaims.LastName,
                    Email = authClaims.Email,
                    CompanyName = authClaims.CompanyName,
                    TrialExpirationDate = DateTime.UtcNow.AddDays(30),
                    SubscriptionType = "Trial"
                };

                await _tenantRepository.CreateTenant(tenant);

                var newTenantId = await _tenantRepository.GetLastCreatedTenantId();

                var newUser = new UserModel
                {
                    TenantID = newTenantId,
                    AzureAD_ObjectID = authClaims.ObjectId,
                    FirstName = authClaims.FirstName,
                    LastName = authClaims.LastName,
                    Email = authClaims.Email,
                    Role = "Owner"
                };

                await _userRepository.CreateUser(newUser);
                var createdUser = await _userRepository.GetUserByObjectId(authClaims.ObjectId);

                if (createdUser != null)
                {
                    var ownerRole = await _roleRepository.GetRolesByNames(new List<string> { "Owner" });

                    if (ownerRole.Any())
                    {
                        await _roleRepository.AssignUserRole(createdUser.UserId, ownerRole.First().RoleId);
                    }
                }
            }
        }

        public async Task<AuthClaimsModel> GetAuthClaimsModel(string objectId)
        {
            var user = await _userRepository.GetUserByObjectId(objectId);

            if (user != null)
            {
                var authClaims = new AuthClaimsModel
                {
                    ObjectId = user.AzureAD_ObjectID,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,


                    // ... additional fields as required
                };

                return authClaims;
            }

            // If there is no user with the provided objectId, return null or throw an exception.
            return null;
        }
    }
}