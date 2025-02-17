using AuraShop.PedidoFacil.API.Data.Dtos;
using AuraShop.PedidoFacil.API.Models;
using AutoMapper;

namespace AuraShop.PedidoFacil.API.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ReadItemDto>()
                .ForMember(dto => dto.ItensPedidos, opt => opt.MapFrom(item => item.ItensPedidos));

            CreateMap<CreateItemDto, Item>();
        }
    }
}
