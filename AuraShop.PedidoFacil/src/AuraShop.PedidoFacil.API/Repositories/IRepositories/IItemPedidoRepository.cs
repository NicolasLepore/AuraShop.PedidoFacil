using AuraShop.PedidoFacil.API.Data.Dtos;
using AuraShop.PedidoFacil.API.Models;

namespace AuraShop.PedidoFacil.API.Repositories.IRepositories
{
    public interface IItemPedidoRepository
    {
        ItemPedido Add(CreateItemPedidoDto dto);
        IEnumerable<ReadItemPedidoDto> GetAll();
    }
}
