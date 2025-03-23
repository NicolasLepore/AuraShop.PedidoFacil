using AuraShop.PedidoFacil.Application.Dtos;
using AuraShop.PedidoFacil.Domain.Models;
using AutoMapper;

namespace AuraShop.PedidoFacil.Infra.Profiles
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
