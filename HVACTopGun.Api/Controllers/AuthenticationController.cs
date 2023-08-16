using Microsoft.AspNetCore.Mvc;

namespace HVACTopGun.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : Controller
{
    private readonly IConfiguration config;

    public AuthenticationController(IConfiguration config)
    {
        this.config = config;
    }


}
