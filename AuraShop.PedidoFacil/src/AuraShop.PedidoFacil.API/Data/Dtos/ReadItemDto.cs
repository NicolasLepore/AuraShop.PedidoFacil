using AuraShop.PedidoFacil.API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuraShop.PedidoFacil.API.Data.Dtos
{
    public class ReadItemDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Tamanho { get; set; }
        public string? Cor { get; set; }
        public virtual ICollection<ItemPedido>? ItensPedidos { get; set; }

    }
}
