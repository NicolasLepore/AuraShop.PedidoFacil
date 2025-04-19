using AuraShop.PedidoFacil.Domain.Models;

namespace AuraShop.PedidoFacil.Application.Dtos
{
    public class ReadPedidoDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public bool Entregue { get; set; } = false;
        public DateTime DataPedido { get; set; }
        public DateTime DataEntrega { get; set; }
        public ReadFaturaDto? Fatura { get; set; }
        public ICollection<ReadItemPedidoDto>? ItensPedidos { get; set; }
    }
}
