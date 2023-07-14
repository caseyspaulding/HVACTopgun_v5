using HVACTopGun.Domain.Features.Auth;

namespace HVACTopGun.Application.Features.Auth;
public interface IAuthService
{
    Task<AuthClaimsModel> GetAuthClaimsModel(string objectId);
    Task ProcessUserAsync(AuthClaimsModel authClaims);
}