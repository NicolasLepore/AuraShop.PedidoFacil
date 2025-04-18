using AuraShop.PedidoFacil.Application.Dtos;
using AuraShop.PedidoFacil.Domain.Models;

namespace AuraShop.PedidoFacil.Application.IRepositories
{
    public interface IItemPedidoRepository
    {
        ItemPedido Add(CreateItemPedidoDto dto);
        IEnumerable<ReadItemPedidoDto> GetAll();
        float GetItemPriceFromItemPedido(int pedidoId, int itemId);
    }
}
