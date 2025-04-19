using AuraShop.PedidoFacil.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuraShop.PedidoFacil.Application.Dtos
{
    public class CreateFaturaDto
    {
        public CreateFaturaDto(int pedidoId)
        {
            PedidoId = pedidoId;
        }

        [Required]
        public double ValorTotal { get; set; } = 0;

        [Required]
        public bool ConfirmacaoPagamentoCliente { get; set; } = false;

        [Required]
        public bool ConfirmacaoPagamentoFornecedor { get; set; } = false;
        public DateTime? DataDePagamento { get; set; } = null;

        [Required]
        public int PedidoId { get; set; }
    }
}
