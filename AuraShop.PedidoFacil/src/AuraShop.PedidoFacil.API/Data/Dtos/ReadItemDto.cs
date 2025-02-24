using AuraShop.PedidoFacil.API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuraShop.PedidoFacil.API.Data.Dtos
{
    public class ReadItemDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Tamanho { get; set; }
        public string? Cor { get; set; }
        public float? Preco { get; set; }

    }
}
