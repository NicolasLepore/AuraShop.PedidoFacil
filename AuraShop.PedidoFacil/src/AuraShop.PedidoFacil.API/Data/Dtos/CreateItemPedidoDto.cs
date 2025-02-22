using AuraShop.PedidoFacil.API.Models;
using System.ComponentModel.DataAnnotations;

namespace AuraShop.PedidoFacil.API.Data.Dtos
{
    public class CreateItemPedidoDto
    {
        [Required]
        public int ItemId { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public int PedidoId { get; set; }
    }
}
