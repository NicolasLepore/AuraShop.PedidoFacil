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
    public class ItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly PedidoFacilContext _context;

        public ItemController(IMapper mapper, PedidoFacilContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateItemDto dto)
        {
            var item = _mapper.Map<Item>(dto);

            _context.Itens.Add(item);
            _context.SaveChanges();

            return Created("", item);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var itens = _context.Itens.AsNoTracking().ToList();  

            var dto = _mapper.Map<IEnumerable<ReadItemDto>>(itens);

            return Ok(dto);
        }

    }
}
