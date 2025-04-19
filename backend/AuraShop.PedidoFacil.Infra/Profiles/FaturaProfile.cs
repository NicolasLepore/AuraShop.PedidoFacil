using AuraShop.PedidoFacil.Application.Dtos;
using AuraShop.PedidoFacil.Domain.Models;
using AutoMapper;

namespace AuraShop.PedidoFacil.Infra.Profiles
{
    public class FaturaProfile : Profile
    {
        public FaturaProfile()
        {
            CreateMap<CreateFaturaDto, Fatura>();
            CreateMap<Fatura, ReadFaturaDto>();
        }
    }
}
