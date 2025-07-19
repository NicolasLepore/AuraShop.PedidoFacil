using AuraShop.PedidoFacil.Application.Dtos;
using AuraShop.PedidoFacil.Application.Models;
using AuraShop.PedidoFacil.Application.Repositories;
using AuraShop.PedidoFacil.Domain.Models;
using AuraShop.PedidoFacil.Infra.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AuraShop.PedidoFacil.Infra.Repositories
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

        public ItemPedidoCalculationDto GetPriceAndAmountFromItens(int pedidoId, int itemId)
        {
            var props = _context.ItensPedidos
                .AsNoTracking()
                .Where(ip => ip.PedidoId == pedidoId && ip.ItemId == itemId)
                .Select(ip => new
                {
                    ip.Item!.Preco,
                    ip.Quantidade
                })
                .FirstOrDefault();

            var dto = new ItemPedidoCalculationDto(props!.Preco ?? 0f, props.Quantidade);

            return dto;
        }
    }
}
