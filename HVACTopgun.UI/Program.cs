using AutoMapper;
using Blazored.LocalStorage;
using HVACTopGun.Application.Common.Mappings;
using HVACTopGun.Application.Features.Auth;
using HVACTopGun.Application.Features.Tenants;
using HVACTopGun.Application.Features.Users;
using HVACTopGun.DataAccess;
using HVACTopGun.DataAccess.Features.Roles;
using HVACTopGun.Domain.Features.Auth;
using HVACTopGun.Services.Extensions;
using HVACTopGun.UI.Features.Scheduler.AutoMapper;
using HVACTopGun.UI.Helpers;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Syncfusion.Blazor;
using System.Security.Claims;
using UserService = HVACTopGun.Application.Features.Users.UserService;

var builder = WebApplication.CreateBuilder(args);
var ConnectionStrings = builder.Configuration["DefaultConnection"];
//Register Sync fusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NGaF5cXmdCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdgWXlcdnVcRWZeVUB1WUM=");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor().AddMicrosoftIdentityConsentHandler();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMemoryCache();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddServerSideBlazor(o => o.DetailedErrors = true);

// Register Services
builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
builder.Services.AddScoped<AuthClaimsModel>();

builder.Services.AddScoped<IAuthorizationHandler, SubscriptionAuthorizationHandler>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(AppointmentMapper));


// Add Service Layer
builder.Services.AddServicesLayer();

// Call the Data Access setup method to register Data Access services
DataAccessSetup.AddDataAccessServices(builder.Services);

// Configure authentication, authorization, and other middleware

//AZURE AD B2C
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(options =>
    {
        ConfigurationBinder.Bind(builder.Configuration.GetSection("AzureAdB2C"), options);
        options.Events = new OpenIdConnectEvents
        {
            OnRedirectToIdentityProvider = async ctxt =>
            {

                await Task.Yield();
            },
            OnAuthenticationFailed = async ctxt =>
            {
                Console.WriteLine(ctxt.Exception.Message); // Output the error message to the console for debugging

                if (ctxt.Exception.Message.Contains("MicrosoftIdentity/Account/Error"))
                {
                    // If the user clicked the cancel button, redirect to home page
                    ctxt.HandleResponse();
                    ctxt.Response.Redirect("/");
                }
                else if (ctxt.Exception.Message.Contains("AADB2C90091"))
                {
                    // If the user clicked the cancel button, redirect to home page
                    ctxt.HandleResponse();
                    ctxt.Response.Redirect("/");
                }
                else if (ctxt.Exception.Message.Contains("AADB2C90118"))
                {
                    // If the user clicked the reset password link, redirect to the reset password route  
                    ctxt.HandleResponse();
                    ctxt.Response.Redirect("/Account/ResetPassword");
                }
                else if (ctxt.Exception.Message.Contains("Error"))
                {
                    // If the user clicked the reset password link, redirect to the reset password route  
                    ctxt.HandleResponse();
                    ctxt.Response.Redirect("/Account/ResetPassword");
                }
                else if (ctxt.Exception.Message.Contains("access_denied"))
                {
                    // If the user clicked the cancel button, redirect to home page
                    ctxt.HandleResponse();
                    ctxt.Response.Redirect("/");
                }
                else
                {
                    // In case of any other exception, redirect to an error page
                    ctxt.HandleResponse();
                    ctxt.Response.Redirect($"/Home/Error?message={Uri.EscapeDataString(ctxt.Exception.Message)}");
                }

                await Task.Yield();
            },
            OnTicketReceived = async ctxt =>
            {
                var tenantDataService = ctxt.HttpContext.RequestServices.GetRequiredService<ITenantService>();
                var userDataService = ctxt.HttpContext.RequestServices.GetRequiredService<IUserService>();

                if (ctxt.Principal.Identity is ClaimsIdentity identity)
                {
                    // Set common values
                    var colClaims = ctxt.Principal.Claims.ToList();

                    AuthClaimsModel objAuthClaims = new AuthClaimsModel
                    {
                        IdentityProvider = colClaims.FirstOrDefault(x => x.Type == "http://schemas.microsoft.com/identity/claims/identityprovider")?.Value,
                        ObjectId = colClaims.FirstOrDefault(x => x.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value,
                        FirstName = colClaims.FirstOrDefault(x => x.Type == "extension_FirstName")?.Value,
                        LastName = colClaims.FirstOrDefault(x => x.Type == "extension_LastName")?.Value,
                        Email = colClaims.FirstOrDefault(x => x.Type == "emails")?.Value,
                        CompanyName = colClaims.FirstOrDefault(x => x.Type == "extension_CompanyName")?.Value
                    };

                    var user = await userDataService.GetUserByObjectId(objAuthClaims.ObjectId);

                    if (user == null)
                    {
                        // Create new tenant
                        var newTenant = new TenantDto
                        {
                            FirstName = objAuthClaims.FirstName,
                            LastName = objAuthClaims.LastName,
                            Email = objAuthClaims.Email,
                            CompanyName = objAuthClaims.CompanyName,
                            TrialExpirationDate = DateTime.UtcNow.AddDays(30),
                            SubscriptionType = "Trial"
                        };

                        await tenantDataService.CreateTenant(newTenant);

                        // Get the newly created Tenant ID
                        var newTenantId = await tenantDataService.GetLastCreatedTenantId();

                        // Create new user with the tenant's ID
                        var newUser = new UserDto
                        {
                            TenantID = newTenantId,
                            AzureAD_ObjectID = objAuthClaims.ObjectId,
                            FirstName = objAuthClaims.FirstName,
                            LastName = objAuthClaims.LastName,
                            Email = objAuthClaims.Email,
                            Role = "Owner"
                        };

                        await userDataService.CreateUser(newUser);
                        var createdUser = await userDataService.GetUserByObjectId(objAuthClaims.ObjectId);

                        if (createdUser != null)
                        {
                            var roleDataService = ctxt.HttpContext.RequestServices.GetRequiredService<IRoleRepository>();
                            var ownerRole = await roleDataService.GetRolesByNames(new List<string> { "Owner" });

                            if (ownerRole.Any())
                            {
                                await roleDataService.AssignUserRole(createdUser.UserId, ownerRole.First().RoleId);
                            }
                        }
                    }
                }
            },
            OnRemoteFailure = context =>
            {
                context.HandleResponse();
                context.Response.Redirect("/Home/Error?message=" + Uri.EscapeDataString(context.Failure.Message));
                return Task.CompletedTask;
            }
        };
    });


builder.Services.AddControllersWithViews().AddMicrosoftIdentityUI();

// ROLES POLICY
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy =>
    {
        policy.RequireClaim("jobTitle", "Admin");
    });
});

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler(errorApp =>
    {
        errorApp.Run(async context =>
        {
            var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            var exception = exceptionHandlerPathFeature?.Error;

            if (exception is Exception ex && ex.Message.Contains("state is null or empty"))
            {
                context.Response.StatusCode = 500; // or another status code that makes sense for your application
                context.Response.ContentType = "text/html";

                await context.Response.SendFileAsync(Path.Combine(app.Environment.ContentRootPath, "wwwroot", "error.html"));
            }
            else
            {
                // Handle other exceptions or provide a generic error response
                // context.Response.StatusCode = 500;
                // context.Response.ContentType = "text/plain";
                // await context.Response.WriteAsync("An error occurred.");
            }
        });
    });

    app.UseHsts();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();


app.UseRewriter(
    new RewriteOptions().Add
    (context =>
    {
        if (context.HttpContext.Request.Path.Value.Contains("/MicrosoftIdentity/Account/SignedOut"))
        {
            context.HttpContext.Response.Redirect("/");
        }
    }));

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");


app.Run();