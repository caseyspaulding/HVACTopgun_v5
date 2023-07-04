using Blazored.LocalStorage;
using DataAccess.Data;
using DataAccess.DataService;
using DataAccess.DbAccess;
using DataAccess.Models;
using HVACTopGun.UI.Helpers;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Syncfusion.Blazor;
using System.Data;
using System.Security.Claims;

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
IServiceCollection serviceCollection = builder.Services.AddScoped<IDbConnection>(c => new SqlConnection(ConnectionStrings));
builder.Services.AddScoped<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddScoped<ITenantDataService, TenantDataService>();
builder.Services.AddScoped<IAppointmentsDataService, AppointmentsDataService>();
builder.Services.AddScoped<IUserDataService, UserDataService>();
builder.Services.AddServerSideBlazor(o => o.DetailedErrors = true);
builder.Services.AddScoped<IAuthorizationHandler, SubscriptionAuthorizationHandler>();
builder.Services.AddScoped<AuthClaimsModel>();
builder.Services.AddScoped<IRoleDataService, RoleDataService>();

//builder.Services.AddScoped<IRoleDataService, RoleDataService>();

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("SubscriptionPolicy", policy =>
//        policy.Requirements.Add(new SubscriptionRequirement()));
//});



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

                await Task.Yield();
            },
            OnTicketReceived = async ctxt =>
            {
                var tenantDataService = ctxt.HttpContext.RequestServices.GetRequiredService<ITenantDataService>();
                var userDataService = ctxt.HttpContext.RequestServices.GetRequiredService<IUserDataService>();

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
                        var newTenant = new TenantModel
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
                        var newUser = new UserModel
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
                            var roleDataService = ctxt.HttpContext.RequestServices.GetRequiredService<IRoleDataService>();
                            var ownerRole = await roleDataService.GetRolesByNames(new List<string> { "Owner" });

                            if (ownerRole.Any())
                            {
                                await roleDataService.AssignUserRole(createdUser.UserId, ownerRole.First().RoleId);
                            }
                        }
                    }
                }
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
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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