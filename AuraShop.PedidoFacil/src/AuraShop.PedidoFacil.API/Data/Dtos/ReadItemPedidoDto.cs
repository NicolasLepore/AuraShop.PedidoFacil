using AuraShop.PedidoFacil.API.Models;
using System.ComponentModel.DataAnnotations;

namespace AuraShop.PedidoFacil.API.Data.Dtos
{
    public class ReadItemPedidoDto
    {
        public int PedidoId { get; set; }
        public virtual ReadItemDto? Item { get; set; }
        public int Quantidade { get; set; }
    }
}
