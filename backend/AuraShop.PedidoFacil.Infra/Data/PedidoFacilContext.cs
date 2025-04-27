using AuraShop.PedidoFacil.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AuraShop.PedidoFacil.Infra.Data
{
    public class PedidoFacilContext : DbContext
    {
        public PedidoFacilContext(DbContextOptions<PedidoFacilContext> opt) : base(opt) { }

        public DbSet<Item> Itens { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedidos { get; set; }
        public DbSet<Fatura> Faturas { get; set; }  

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

            builder.Entity<Pedido>()
                .HasOne(p => p.Fatura)
                .WithOne(f => f.Pedido);

        }


    }
}
