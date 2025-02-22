using AuraShop.PedidoFacil.API.Data;
using AuraShop.PedidoFacil.API.Data.Dtos;
using AuraShop.PedidoFacil.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuraShop.PedidoFacil.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ItemPedidoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly PedidoFacilContext _context;

        public ItemPedidoController(IMapper mapper, PedidoFacilContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateItemPedidoDto dto)
        {
            var itemPedido = _mapper.Map<ItemPedido>(dto);

            _context.ItensPedidos.Add(itemPedido);
            _context.SaveChanges();

            //var pedido = _context.Pedidos.AsNoTracking().FirstOrDefault(p => p.Id == dto.PedidoId);

            //Console.WriteLine(pedido.Nome);

            //PRECISO CRIAR LOGO OS Repositories para fazer esse tipo de lógica!

            return Created("", itemPedido);
           
        }

        [HttpGet]
        public IActionResult Get()
        {
            var itensPedidos = _context.ItensPedidos.AsNoTracking().ToList();

            var dto = _mapper.Map<IEnumerable<ReadItemPedidoDto>>(itensPedidos);

            return Ok(dto);
        }
    }
}
