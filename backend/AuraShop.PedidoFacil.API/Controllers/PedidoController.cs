using AuraShop.PedidoFacil.Application.Dtos;
using AuraShop.PedidoFacil.Application.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace AuraShop.PedidoFacil.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository _repo;
        public PedidoController(IPedidoRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreatePedidoDto dto)
        {
            var pedido = _repo.Add(dto);

            return Created("", pedido);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var dto = _repo.GetAll();

            return Ok(dto);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var dto = _repo.GetById(id);

            if (dto is null) return NotFound();

            return Ok(dto);
        }
    }
}
