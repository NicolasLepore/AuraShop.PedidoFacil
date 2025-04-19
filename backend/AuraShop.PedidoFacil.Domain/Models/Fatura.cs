using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        public DateTime? DataDePagamento { get; set; } = null;

        [Required]
        public int PedidoId { get; set; }

        [JsonIgnore]
        public virtual Pedido? Pedido { get; set; }
    }
}
