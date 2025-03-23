using AuraShop.PedidoFacil.Application.Dtos;
using AuraShop.PedidoFacil.Domain.Models;
using AutoMapper;

namespace AuraShop.PedidoFacil.Infra.Profiles
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
