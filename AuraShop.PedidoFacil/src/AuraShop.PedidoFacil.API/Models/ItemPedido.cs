using System.ComponentModel.DataAnnotations;

namespace AuraShop.PedidoFacil.API.Models
{
    public class ItemPedido
    {
        public int ItemId { get; set; }
        public virtual Item? Item { get; set; }
        public int Quantidade { get; set; }
        public int PedidoId { get; set; }
        public virtual Pedido? Pedido { get; set; }
    }
}
