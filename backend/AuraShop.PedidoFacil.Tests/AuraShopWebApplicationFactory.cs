using AuraShop.PedidoFacil.Infra.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AuraShop.PedidoFacil.Tests;
public class AuraShopWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Preciso ver como criar banco de testes para esse caso. Talvez usar o docker - se for usar docker reveja no curso
            string conn = "server=localhost;user=root;password=root;database=AuraShopPedidoFacilTests;";

            services.RemoveAll(typeof(DbContextOptions<PedidoFacilContext>));
            services.AddDbContext<PedidoFacilContext>(opt =>
            {
                opt.UseLazyLoadingProxies()
                    .UseMySql(conn, ServerVersion.AutoDetect(conn));

            });

            var provider = services.BuildServiceProvider();
            using(var scope = provider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<PedidoFacilContext>();

                context.Database.Migrate();
            }

        });

        base.ConfigureWebHost(builder);
        
    }
}
