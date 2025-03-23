using AuraShop.PedidoFacil.Application.Dtos;
using AuraShop.PedidoFacil.Application.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace AuraShop.PedidoFacil.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ItemPedidoController : ControllerBase
    {
        private readonly IItemPedidoRepository _repo;

        public ItemPedidoController(IItemPedidoRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateItemPedidoDto dto)
        {
            var itemPedido = _repo.Add(dto);

            //PRECISO CRIAR A LÓGICA PARA CALCULAR O TOTAL!
            //FOCO EM PRECISÃO NO CÁLCULO, FLEXIBILIDADE DE CÓDIGO E DESEMPENHO COMPUTACIONAL

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
