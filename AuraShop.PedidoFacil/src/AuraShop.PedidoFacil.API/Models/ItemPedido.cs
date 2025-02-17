using System.ComponentModel.DataAnnotations;

namespace AuraShop.PedidoFacil.API.Models
{
    public class ItemPedido
    {
        [Required]
        public int ItemId { get; set; }

        [Required]
        public virtual Item? Item { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public int PedidoId { get; set; }

        [Required]
        public virtual Pedido? Pedido { get; set; }
    }
}
