using AuraShop.PedidoFacil.Application.Dtos;
using AuraShop.PedidoFacil.Domain.Models;

namespace AuraShop.PedidoFacil.Application.IRepositories
{
    public interface IItemRepository
    {
        Item Add(CreateItemDto dto);
        IEnumerable<ReadItemDto> GetAll();
        ReadItemDto GetById(int id);
        ReadItemDto GetByNameAndSize(string name, string size);
        bool Delete(int id);

    }
}
