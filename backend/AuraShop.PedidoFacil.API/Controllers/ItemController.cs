using AuraShop.PedidoFacil.Application.Dtos;
using AuraShop.PedidoFacil.Application.Repositories;
using AuraShop.PedidoFacil.Domain.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "User")]
        [ProducesResponseType(typeof(Item), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] CreateItemDto dto)
        {
            var item = _repo.Add(dto);

            return Created("", item);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ReadItemDto>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var dto = _repo.GetAll();

            return Ok(dto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReadItemDto), StatusCodes.Status200OK)]
        [ProducesResponseType
            (typeof(NotFoundResult), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var dto = _repo.GetById(id);

            if (dto is null) return NotFound();

            return Ok(dto);
        }

        [HttpGet("{name}/{size}")]
        [ProducesResponseType(typeof(ReadItemDto), StatusCodes.Status200OK)]
        [ProducesResponseType
            (typeof(NotFoundResult), StatusCodes.Status404NotFound)]
        public IActionResult GetByNameAndSize(string name, string size)
        {
            var dto = _repo.GetByNameAndSize(name, size);

            if (dto is null)
            {
                return NotFound
                (
                    new { StatusCode = StatusCodes.Status404NotFound, ErrorMessage = "Item não encontrado por esse nome e tamanho" }
                );
            }


            return Ok(dto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType
            (typeof(NoContentResult), StatusCodes.Status204NoContent)]
        [ProducesResponseType
            (typeof(NotFoundResult), StatusCodes.Status404NotFound)]
        public IActionResult Update(int id, [FromBody] UpdateItemDto dto)
        {
            var success = _repo.Update(id, dto);

            if (!success) return NotFound();

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ProducesResponseType
            (typeof(NoContentResult), StatusCodes.Status204NoContent)]
        [ProducesResponseType
            (typeof(NotFoundResult), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            bool itemFound = _repo.Delete(id);

            if (!itemFound) return NotFound();

            return NoContent();
        }

    }
}
