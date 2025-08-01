using AuraShop.PedidoFacil.Application.Interfaces;
using AuraShop.PedidoFacil.Application.Repositories;
using AuraShop.PedidoFacil.Application.Services;
using AuraShop.PedidoFacil.Application.UseCases;
using AuraShop.PedidoFacil.Infra.Data;
using AuraShop.PedidoFacil.Infra.Identity;
using AuraShop.PedidoFacil.Infra.Identity.Models;
using AuraShop.PedidoFacil.Infra.Repositories;
using AuraShop.PedidoFacil.Infra.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string conn = builder.Configuration.GetConnectionString("Connection")!;
string identityConn = builder.Configuration.GetConnectionString("IdentityConnection")!;

builder.Services.AddDbContext<IdentityContext>(opt =>
{
    opt.UseLazyLoadingProxies()
        .UseMySql(identityConn, ServerVersion.AutoDetect(identityConn));
});

builder.Services.AddDbContext<PedidoFacilContext>(opt =>
{
    opt.UseLazyLoadingProxies()
        .UseMySql(conn, ServerVersion.AutoDetect(conn));
});

builder.Services
    .AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireUppercase = false;

    opt.Lockout.MaxFailedAccessAttempts = 3;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IItemPedidoRepository, ItemPedidoRepository>();

builder.Services.AddScoped<FaturaService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<CreateItemPedidoUseCase>();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(c =>
{

    c.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
});

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

using(var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    await RoleSeeder.Seed(userManager, roleManager);
}

app.Run();

public partial class Program { }