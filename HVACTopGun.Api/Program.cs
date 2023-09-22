using HVACTopGun.DataAccess.DataAccess;
using HVACTopGun.DataAccess.Features.Tenants;
using HVACTopGun.DataAccess.Features.Users;
using HVACTopGun.Services.Features.Auth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<AuthClaimsDto>();
builder.Services.AddScoped<ITenantRepository, TenantRepository>();
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();