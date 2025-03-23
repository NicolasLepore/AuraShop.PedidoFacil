using AuraShop.PedidoFacil.Application.Dtos;
using AuraShop.PedidoFacil.Domain.Models;
using AutoMapper;

namespace AuraShop.PedidoFacil.Infra.Profiles
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
