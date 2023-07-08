using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace HVACTopGun.UI.Helpers
{
    public class AuthenticationEvents : OpenIdConnectEvents
    {
        public override Task RemoteFailure(RemoteFailureContext context)
        {
            context.HandleResponse();
            context.Response.Redirect("/error");
            return Task.CompletedTask;
        }
    }
}
