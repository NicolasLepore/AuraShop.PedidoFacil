using AuraShop.PedidoFacil.Application.Dtos;
using AuraShop.PedidoFacil.Application.IRepositories;
using AuraShop.PedidoFacil.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace AuraShop.PedidoFacil.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ItemPedidoController : ControllerBase
    {
        private readonly IItemPedidoRepository _repo;
        private readonly CreateItemPedidoUseCase _createUseCase;

        public ItemPedidoController(IItemPedidoRepository repo, CreateItemPedidoUseCase createUseCase)
        {
            _repo = repo;
            _createUseCase = createUseCase;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateItemPedidoDto dto)
        {
            var itemPedido = _createUseCase.Execute(dto);

            return Created("", itemPedido);
           
        }

        [HttpGet]
        public IActionResult Get()
        {
            var dto = _repo.GetAll();

            return Ok(dto);
        }
    }
}
