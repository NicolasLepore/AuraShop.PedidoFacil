using AuraShop.PedidoFacil.Application.Dtos;
using AuraShop.PedidoFacil.Application.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace AuraShop.PedidoFacil.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ItemController : ControllerBase
    {
        private IItemRepository _repo;

        public ItemController(IItemRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateItemDto dto)
        {
            var item = _repo.Add(dto);

            return Created("", item);
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

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool itemFound = _repo.Delete(id);

            if (!itemFound) return NotFound();

            return NoContent();
        }

    }
}
