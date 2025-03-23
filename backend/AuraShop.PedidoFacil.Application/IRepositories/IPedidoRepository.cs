using AuraShop.PedidoFacil.Application.Dtos;
using AuraShop.PedidoFacil.Domain.Models;

namespace AuraShop.PedidoFacil.Application.IRepositories
{
    public interface IPedidoRepository
    {
        Pedido Add(CreatePedidoDto dto);
        IEnumerable<ReadPedidoDto> GetAll();
        ReadPedidoDto GetById(int id);
    }
}
