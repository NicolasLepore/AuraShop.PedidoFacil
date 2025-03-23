namespace AuraShop.PedidoFacil.Application.Dtos
{
    public class ReadItemPedidoDto
    {
        public int PedidoId { get; set; }
        public virtual ReadItemDto? Item { get; set; }
        public int Quantidade { get; set; }
    }
}
