using AuraShop.PedidoFacil.Application.Dtos;
using AuraShop.PedidoFacil.Application.Repositories;
using AuraShop.PedidoFacil.Domain.Models;
using AuraShop.PedidoFacil.Infra.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuraShop.PedidoFacil.Infra.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly IMapper _mapper;
        private readonly PedidoFacilContext _context;

        public PedidoRepository(IMapper mapper, PedidoFacilContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Pedido Add(CreatePedidoDto dto)
        {
            var pedido = _mapper.Map<Pedido>(dto);

            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            return pedido;
        }

        public IEnumerable<ReadPedidoDto> GetAll()
        {
            var pedidos = _context.Pedidos.AsNoTracking().ToList();
            var dto = _mapper.Map<IEnumerable<ReadPedidoDto>>(pedidos);

            return dto;
        }

        public ReadPedidoDto GetById(int id)
        {
            var pedido = _context.Pedidos.AsNoTracking().FirstOrDefault(p => p.Id == id);

            var dto = _mapper.Map<ReadPedidoDto>(pedido);
           
            return dto;
        }

        public void CreateFatura(int pedidoId)  
        {
            var dto = new CreateFaturaDto(pedidoId);
            
            var fatura = _mapper.Map<Fatura>(dto);

            _context.Faturas.Add(fatura);
            _context.SaveChanges();
        }

        public bool UpdateFaturaFromPedido(int pedidoId, double valorTotal)
        {
            var pedido = _context.Pedidos.FirstOrDefault(p => p.Id == pedidoId);

            if (pedido is null) return false;

            valorTotal = Math.Round(valorTotal, 2);

            pedido.Fatura!.ValorTotal += valorTotal;
            _context.SaveChanges();

            return true;
        }
    }
}
