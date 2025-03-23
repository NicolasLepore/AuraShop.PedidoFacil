using System.ComponentModel.DataAnnotations;

namespace AuraShop.PedidoFacil.Application.Dtos
{
    public class CreatePedidoDto
    {
        [MaxLength(25)]
        public string? Nome { get; set; }
        public bool Pago { get; set; } = false;
        public bool Entregue { get; set; } = false;
        public DateTime? DataEntrega { get; set; } = null;
    }
}
