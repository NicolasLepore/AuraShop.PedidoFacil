using AuraShop.PedidoFacil.API.Data;
using AuraShop.PedidoFacil.API.Data.Dtos;
using AuraShop.PedidoFacil.API.Models;
using AuraShop.PedidoFacil.API.Repositories.IRepositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuraShop.PedidoFacil.API.Repositories
{
    public class ItemPedidoRepository : IItemPedidoRepository
    {
        private readonly IMapper _mapper;
        private readonly PedidoFacilContext _context;

        public ItemPedidoRepository(IMapper mapper, PedidoFacilContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public ItemPedido Add(CreateItemPedidoDto dto)
        {
            var itemPedido = _mapper.Map<ItemPedido>(dto);

            _context.ItensPedidos.Add(itemPedido);
            _context.SaveChanges();

            return itemPedido;

        }

        public IEnumerable<ReadItemPedidoDto> GetAll()
        {
            var itensPedidos = _context.ItensPedidos.AsNoTracking().ToList();

            var dto = _mapper.Map<IEnumerable<ReadItemPedidoDto>>(itensPedidos);

            return dto;
        }
    }
}
