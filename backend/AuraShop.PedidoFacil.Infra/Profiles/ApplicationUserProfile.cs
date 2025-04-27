using AuraShop.PedidoFacil.Application.Dtos.Request;
using AuraShop.PedidoFacil.Infra.Identity.Models;
using AutoMapper;

namespace AuraShop.PedidoFacil.Infra.Profiles
{
    public class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateMap<RegisterApplicationUserRequest, ApplicationUser>();
        }
    }
}
