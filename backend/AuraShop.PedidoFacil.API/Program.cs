using AuraShop.PedidoFacil.Application.IRepositories;
using AuraShop.PedidoFacil.Infra.Data;
using AuraShop.PedidoFacil.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string conn = builder.Configuration.GetConnectionString("Connection")!;

builder.Services.AddDbContext<PedidoFacilContext>(opt =>
{
    opt.UseLazyLoadingProxies().UseMySql(conn, ServerVersion.AutoDetect(conn));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Dependencias
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IItemPedidoRepository, ItemPedidoRepository>();

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

app.UseAuthorization();
app.MapControllers();

app.Run();
