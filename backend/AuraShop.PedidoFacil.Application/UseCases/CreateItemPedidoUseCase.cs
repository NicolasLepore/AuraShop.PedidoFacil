using AuraShop.PedidoFacil.Application.Dtos;
using AuraShop.PedidoFacil.Application.IRepositories;
using AuraShop.PedidoFacil.Application.Services;
using AuraShop.PedidoFacil.Domain.Models;

namespace AuraShop.PedidoFacil.Application.UseCases;
public class CreateItemPedidoUseCase
{
    private readonly FaturaService _faturaService;
    private readonly IItemPedidoRepository _repoItemPedido;
    private readonly IPedidoRepository _repoPedido;

    public CreateItemPedidoUseCase(FaturaService faturaService, IItemPedidoRepository repoItemPedido, IPedidoRepository repoPedido)
    {
        _faturaService = faturaService;
        _repoItemPedido = repoItemPedido;
        _repoPedido = repoPedido;
    }

    public ItemPedido Execute(CreateItemPedidoDto dto)
    {
        // Adiciona no banco
        var itemPedido = _repoItemPedido.Add(dto);

        // Busca o mesmo objeto de ItemPedido no Banco e retorna o DTO para calculo da fatura.
        var itemPedidoDto = _repoItemPedido
            .GetPriceAndAmountFromItens(itemPedido.PedidoId, itemPedido.ItemId);
        
        // Buscando o pedido para alteração na Fatura.
        var pedido = _repoPedido.GetById(itemPedido.PedidoId);

        _faturaService.CalcularValorTotal(itemPedidoDto, pedido);

        return itemPedido;
    }
}
