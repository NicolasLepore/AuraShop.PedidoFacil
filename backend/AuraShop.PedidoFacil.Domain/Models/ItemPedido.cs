using System.Text.Json.Serialization;

namespace AuraShop.PedidoFacil.Domain.Models
{
    public class ItemPedido
    {
        public int ItemId { get; set; }
        public virtual Item? Item { get; set; }
        public int Quantidade { get; set; }
        public int PedidoId { get; set; }

        [JsonIgnore]
        public virtual Pedido? Pedido { get; set; }
    }
}
