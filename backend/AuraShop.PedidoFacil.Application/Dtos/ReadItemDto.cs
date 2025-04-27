using AuraShop.PedidoFacil.Domain.Models;

namespace AuraShop.PedidoFacil.Application.Dtos
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
