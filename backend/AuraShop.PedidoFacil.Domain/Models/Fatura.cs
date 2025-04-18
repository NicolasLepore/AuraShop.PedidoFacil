using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuraShop.PedidoFacil.Domain.Models
{
    public class Fatura
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public double ValorTotal { get; set; }

        [Required]
        public bool ConfirmacaoPagamentoCliente { get; set; } = false;

        [Required]
        public bool ConfirmacaoPagamentoFornecedor { get; set; } = false;

        [Required]
        public int PedidoId { get; set; }

        [Required]
        public DateTime DataDePagamento { get; set; }
        public virtual Pedido? Pedido { get; set; }
    }
}
