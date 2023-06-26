using Microsoft.AspNetCore.Identity;
using TaskManagement.Domain.Models;
using TaskManagement.Infrastructure;
using TaskManagement.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// add identity
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

//var identityServerBuilder = builder.Services.AddIdentityServer()
//    .AddInMemoryPersistedGrants()
//    .AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResources())
//    .AddInMemoryApiScopes(IdentityServerConfig.GetApiScopes())
//    .AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
//    .AddInMemoryClients(IdentityServerConfig.GetClients())
//    .AddAspNetIdentity<ApplicationUser>()
//    .AddProfileService<ProfileService>()
//    .AddCustomTokenRequestValidator<CustomValidationToken>();

// Configure Identity options and password complexity here
builder.Services.Configure<IdentityOptions>(options =>
{
    options.User.RequireUniqueEmail = true;
});
//builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(AutoMapperProfile)));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
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
