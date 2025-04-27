using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuraShop.PedidoFacil.Application.Dtos
{
    public class UpdateItemDto
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
