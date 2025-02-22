using AuraShop.PedidoFacil.API.Data.Dtos;
using AuraShop.PedidoFacil.API.Models;
using AutoMapper;

namespace AuraShop.PedidoFacil.API.Profiles
{
    public class ItemPedidoProfile : Profile
    {
        public ItemPedidoProfile()
        {
            CreateMap<CreateItemPedidoDto, ItemPedido>();
            CreateMap<ItemPedido, ReadItemPedidoDto>()
                .ForMember(dto => dto.Item, opt => 
                    opt.MapFrom(ip => ip.Item));
        }
    }
}
