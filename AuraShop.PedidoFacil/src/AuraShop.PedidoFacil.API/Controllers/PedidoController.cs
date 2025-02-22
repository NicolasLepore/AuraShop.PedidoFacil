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
    public class PedidoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly PedidoFacilContext _context;
        public PedidoController(IMapper mapper, PedidoFacilContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreatePedidoDto dto)
        {
            var pedido = _mapper.Map<Pedido>(dto);

            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            return Created("", pedido);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pedidos = _context.Pedidos.AsNoTracking().ToList();
            var dto = _mapper.Map<IEnumerable<ReadPedidoDto>>(pedidos);

            return Ok(dto);
        }
    }
}
