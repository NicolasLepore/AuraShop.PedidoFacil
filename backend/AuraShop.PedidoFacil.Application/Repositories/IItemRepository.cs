using AuraShop.PedidoFacil.Application.Dtos;
using AuraShop.PedidoFacil.Domain.Models;

namespace AuraShop.PedidoFacil.Application.Repositories
{
    public interface IItemRepository
    {
        Item Add(CreateItemDto dto);
        IEnumerable<ReadItemDto> GetAll();
        ReadItemDto GetById(int id);
        ReadItemDto GetByNameAndSize(string name, string size);
        bool Update(int id, UpdateItemDto dto);
        bool Delete(int id);

    }
}
