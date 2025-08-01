﻿using AuraShop.PedidoFacil.Application.Dtos;
using AuraShop.PedidoFacil.Application.Repositories;
using AuraShop.PedidoFacil.Domain.Models;
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
        [ProducesResponseType(typeof(Pedido), StatusCodes.Status201Created)]
        [ProducesResponseType
            (typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] CreatePedidoDto dto)
        {
            var pedido = _repo.Add(dto);
            _repo.CreateFatura(pedido.Id);

            return Created("", pedido);
        }

        [HttpGet]
        [ProducesResponseType
            (typeof(IEnumerable<ReadPedidoDto>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var dto = _repo.GetAll();

            return Ok(dto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReadPedidoDto), StatusCodes.Status200OK)]
        [ProducesResponseType
            (typeof(NotFoundResult), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var dto = _repo.GetById(id);

            if (dto is null) return NotFound();

            return Ok(dto);
        }
    }
}
