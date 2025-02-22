using AuraShop.PedidoFacil.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AuraShop.PedidoFacil.API.Data
{
    public class PedidoFacilContext : DbContext
    {
        public PedidoFacilContext(DbContextOptions opt) : base(opt) { }

        public DbSet<Item> Itens { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ItemPedido>()
                .HasKey(ip => new { ip.ItemId, ip.PedidoId });

            builder.Entity<ItemPedido>()
                .HasOne(ip => ip.Item)
                .WithMany(i => i.ItensPedidos)
                .HasForeignKey(ip => ip.ItemId);

            builder.Entity<ItemPedido>()
                .HasOne(ip => ip.Pedido)
                .WithMany(p => p.ItensPedidos)
                .HasForeignKey(ip => ip.PedidoId);

        }

       
    }
}
