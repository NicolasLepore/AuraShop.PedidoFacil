using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace AuraShop.PedidoFacil.Domain.Models
{
    public class Pedido
    {

        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(25)]
        public string? Nome { get; set; }

        [Required]
        public bool Entregue { get; set; } = false;

        [Required]
        public DateTime DataPedido { get; set; } = DateTime.Now;

        [AllowNull]
        public DateTime? DataEntrega { get; set; } = null;

        public virtual Fatura? Fatura { get; set; }

        public virtual ICollection<ItemPedido>? ItensPedidos { get; set; }
    }
}
