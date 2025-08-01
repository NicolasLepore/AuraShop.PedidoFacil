﻿using AuraShop.PedidoFacil.Application.Dtos;
using AuraShop.PedidoFacil.Domain.Models;

namespace AuraShop.PedidoFacil.Application.Repositories
{
    public interface IPedidoRepository
    {
        Pedido Add(CreatePedidoDto dto);
        IEnumerable<ReadPedidoDto> GetAll();
        ReadPedidoDto GetById(int id);
        void CreateFatura(int pedidoId);
        public bool UpdateFaturaFromPedido(int pedidoId, double valorTotal);
    }
}
