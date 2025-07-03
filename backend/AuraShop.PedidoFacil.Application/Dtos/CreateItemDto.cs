using System.ComponentModel.DataAnnotations;

namespace AuraShop.PedidoFacil.Application.Dtos
{
    public class CreateItemDto
    {
        [Required]
        [MaxLength(25)]
        public string? Nome { get; set; }

        [Required]
        [MaxLength(4)]
        public string? Tamanho { get; set; }

        [Required]
        [MaxLength(15)]
        public string? Cor { get; set; }

        [Required]
        public float? Preco { get; set; }
    }
}
