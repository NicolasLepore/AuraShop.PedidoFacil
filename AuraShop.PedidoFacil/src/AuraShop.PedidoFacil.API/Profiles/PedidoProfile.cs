using AuraShop.PedidoFacil.API.Data.Dtos;
using AuraShop.PedidoFacil.API.Models;
using AutoMapper;

namespace AuraShop.PedidoFacil.API.Profiles
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            CreateMap<Pedido, ReadPedidoDto>()
                .ForMember(dto => dto.ItensPedidos, opt => 
                    opt.MapFrom(pedido => pedido.ItensPedidos));

            CreateMap<CreatePedidoDto, Pedido>();
        }
    }
}
