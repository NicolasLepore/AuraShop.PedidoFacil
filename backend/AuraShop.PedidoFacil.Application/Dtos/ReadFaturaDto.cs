using AuraShop.PedidoFacil.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AuraShop.PedidoFacil.Application.Dtos;
public class ReadFaturaDto
{
    public int Id { get; set; }
    public double ValorTotal { get; set; }
    public bool ConfirmacaoPagamentoCliente { get; set; } = false;
    public bool ConfirmacaoPagamentoFornecedor { get; set; } = false;
    public DateTime DataDePagamento { get; set; }
}
