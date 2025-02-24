using AuraShop.PedidoFacil.API.Data;
using AuraShop.PedidoFacil.API.Data.Dtos;
using AuraShop.PedidoFacil.API.Models;
using AuraShop.PedidoFacil.API.Repositories.IRepositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuraShop.PedidoFacil.API.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly IMapper _mapper;
        private readonly PedidoFacilContext _context;

        public ItemRepository(IMapper mapper, PedidoFacilContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Item Add(CreateItemDto dto)
        {
            var item = _mapper.Map<Item>(dto);

            _context.Itens.Add(item);
            _context.SaveChanges();

            return item;
        }
        public IEnumerable<ReadItemDto> GetAll()
        {
            var itens = _context.Itens.AsNoTracking().ToList();

            var dto = _mapper.Map<IEnumerable<ReadItemDto>>(itens);

            return dto;
        }

        public ReadItemDto GetById(int id)
        {
            Item? item = _context.Itens.AsNoTracking().FirstOrDefault(i => i.Id == id);

            var dto = _mapper.Map<ReadItemDto>(item);

            return dto;
        }

        public bool Delete(int id)
        {
            var item = _context.Itens.FirstOrDefault(i => i.Id == id);

            if(item is null) return false;

            _context.Itens.Remove(item);
            _context.SaveChanges();

            return true;
        }

    }
}
