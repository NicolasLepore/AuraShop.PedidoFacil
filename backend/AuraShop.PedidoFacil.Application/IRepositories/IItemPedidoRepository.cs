using AuraShop.PedidoFacil.Application.Dtos;
using AuraShop.PedidoFacil.Application.Models;
using AuraShop.PedidoFacil.Domain.Models;

namespace AuraShop.PedidoFacil.Application.IRepositories
{
    public interface IItemPedidoRepository
    {
        ItemPedido Add(CreateItemPedidoDto dto);
        IEnumerable<ReadItemPedidoDto> GetAll();
        ItemPedidoCalculationDto GetPriceAndAmountFromItens(int pedidoId, int itemId);
    }
}
