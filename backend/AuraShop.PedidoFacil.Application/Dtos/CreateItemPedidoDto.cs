using System.ComponentModel.DataAnnotations;

namespace AuraShop.PedidoFacil.Application.Dtos
{
    public class CreateItemPedidoDto
    {
        [Required]
        public int PedidoId { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        public int Quantidade { get; set; }

    }
}
