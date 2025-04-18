using AuraShop.PedidoFacil.Application.Dtos;
using AuraShop.PedidoFacil.Application.IRepositories;
using AuraShop.PedidoFacil.Application.Services;
using AuraShop.PedidoFacil.Domain.Models;

namespace AuraShop.PedidoFacil.Application.UseCases;
public class CreateItemPedidoUseCase
{
    private readonly FaturaService _faturaService;
    private readonly IItemPedidoRepository _repo;

    public CreateItemPedidoUseCase(FaturaService faturaService, IItemPedidoRepository repo)
    {
        _faturaService = faturaService;
        _repo = repo;
    }

    public ItemPedido Execute(CreateItemPedidoDto dto)
    {
        var itemPedido = _repo.Add(dto);

        float precoItem = _repo.GetItemPriceFromItemPedido(itemPedido.PedidoId, itemPedido.ItemId);

        _faturaService.CalcularValorTotal(precoItem);

        return itemPedido;
    }
}
