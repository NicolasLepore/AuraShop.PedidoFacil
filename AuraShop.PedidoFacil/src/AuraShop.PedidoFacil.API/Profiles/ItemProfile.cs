using AuraShop.PedidoFacil.API.Data.Dtos;
using AuraShop.PedidoFacil.API.Models;
using AutoMapper;

namespace AuraShop.PedidoFacil.API.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ReadItemDto>();

            CreateMap<CreateItemDto, Item>();
        }
    }
}
