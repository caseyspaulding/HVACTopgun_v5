using Auth0.AspNetCore.Authentication;
using Blazored.LocalStorage;
using Microsoft.Data.SqlClient;
using Syncfusion.Blazor;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
var ConnectionStrings = builder.Configuration["DefaultConnection"];
//Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt+QHJqVk1hXk5Hd0BLVGpAblJ3T2ZQdVt5ZDU7a15RRnVfR19jSHpXf0BrW31Wcw==;Mgo+DSMBPh8sVXJ1S0R+X1pFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF5jTHxTd0FnUHpWcnBXRQ==;ORg4AjUWIQA/Gnt2VFhiQlJPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSXtRdkRnXXZbeHZQQGM=;MjEyOTkzOUAzMjMxMmUzMjJlMzNVUzk2c093amtqdW9VSGRxSDhXNGpDM2JyVDNQNXd6WTQ0LzZVeFBxM3djPQ==;MjEyOTk0MEAzMjMxMmUzMjJlMzNKYmw5N3dsbGh1dWg1N2lvMnBOc3lSK3FqL3NwVW1IZUJvOWlPdUhqYXd3PQ==;NRAiBiAaIQQuGjN/V0d+Xk9HfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5WdEViXXtXdXxWRGJf;MjEyOTk0MkAzMjMxMmUzMjJlMzNtVDBURjZrWk1zOUg0Nlh4U3NIaTB3VWFuWEhsN1B5a2hreHNSTllSbWhrPQ==;MjEyOTk0M0AzMjMxMmUzMjJlMzNUcENsKzlqeVY1ZUw4M2ZhTkk4ek5EYVN2Q3QveWRjdVFYeGlQUGU1OWxVPQ==;Mgo+DSMBMAY9C3t2VFhiQlJPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSXtRdkRnXXZbeHdcR2M=;MjEyOTk0NUAzMjMxMmUzMjJlMzNWTDgzL3ZRQWNvMDhrbUZpWGgxcnE1dGVhdEFHaUI4N3dmcHVOcC9NbUlnPQ==;MjEyOTk0NkAzMjMxMmUzMjJlMzNBeWk1enBSN0x6dHEwTk1WQ0hrTjBHeDRVQ2lwQXpyL2NubDV1UkZHZEF3PQ==;MjEyOTk0N0AzMjMxMmUzMjJlMzNtVDBURjZrWk1zOUg0Nlh4U3NIaTB3VWFuWEhsN1B5a2hreHNSTllSbWhrPQ==");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddSyncfusionBlazor();
IServiceCollection serviceCollection = builder.Services.AddScoped<IDbConnection>(c => new SqlConnection(ConnectionStrings));

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});


builder.Services
    .AddAuth0WebAppAuthentication(options =>
    {
        options.Domain = builder.Configuration["Auth0:Domain"];
        options.ClientId = builder.Configuration["Auth0:ClientId"];
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();