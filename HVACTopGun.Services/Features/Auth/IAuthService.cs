using HVACTopGun.Domain.Features.Auth;

namespace HVACTopGun.Services.Features.Auth;
public interface IAuthService
{
    Task<AuthClaimsModel> GetAuthClaimsModel(string objectId);
    Task ProcessUserAsync(AuthClaimsModel authClaims);
}