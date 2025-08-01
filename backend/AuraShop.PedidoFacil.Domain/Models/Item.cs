﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuraShop.PedidoFacil.Domain.Models
{
    public class Item
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string? Nome { get; set; }

        [Required]
        [MaxLength(10)]
        public string? Tamanho { get; set; }

        [Required]
        [MaxLength(15)]
        public string? Cor { get; set; }

        [Required]
        public float? Preco { get; set; }

        public virtual ICollection<ItemPedido>? ItensPedidos { get; set; }

    }
}
