using AuraShop.PedidoFacil.API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuraShop.PedidoFacil.API.Data.Dtos
{
    public class ReadPedidoDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }    
        public bool Pago { get; set; } = false;
        public bool Entregue { get; set; } = false;
        public DateTime DataPedido { get; set; }
        public DateTime DataEntrega { get; set; }
        public float ValorTotal { get; set; }
        public virtual ICollection<ReadItemPedidoDto>? ItensPedidos { get; set; }
    }
}
