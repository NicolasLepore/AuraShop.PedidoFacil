using AuraShop.PedidoFacil.Application.Dtos;
using AuraShop.PedidoFacil.Application.IRepositories;
using AuraShop.PedidoFacil.Application.Models;

namespace AuraShop.PedidoFacil.Application.Services
{
    public class FaturaService
    {
        private readonly IPedidoRepository _repo;

        public FaturaService(IPedidoRepository repo)
        {
            _repo = repo;
        }

        public void CalcularValorTotal(ItemPedidoCalculationDto itemPedidoDto, ReadPedidoDto pedido)
        {
            double valorTotal = itemPedidoDto.Quantidade * itemPedidoDto.Preco;

            // Ponto de Melhoria, validar e retornar Exception.
            bool success = _repo.UpdateFaturaFromPedido(pedido.Id, valorTotal);
        }
    }
}
