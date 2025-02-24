using AuraShop.PedidoFacil.API.Data.Dtos;
using AuraShop.PedidoFacil.API.Models;

namespace AuraShop.PedidoFacil.API.Repositories.IRepositories
{
    public interface IItemRepository
    {
        Item Add(CreateItemDto dto);
        IEnumerable<ReadItemDto> GetAll();
        ReadItemDto GetById(int id);
        bool Delete(int id);
    }
}
