using AuraShop.PedidoFacil.API.Data.Dtos;
using AuraShop.PedidoFacil.API.Models;

namespace AuraShop.PedidoFacil.API.Repositories.IRepositories
{
    public interface IPedidoRepository
    {
        Pedido Add(CreatePedidoDto dto);
        IEnumerable<ReadPedidoDto> GetAll();
        ReadPedidoDto GetById(int id);
    }
}
