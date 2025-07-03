using AuraShop.PedidoFacil.Application.Dtos.Request;
using AuraShop.PedidoFacil.Application.Dtos.Response;

namespace AuraShop.PedidoFacil.Application.Interfaces
{
    public interface IAuthService
    {
        public Task<bool> Register(RegisterApplicationUserRequest request);

        public Task<LoginApplicationUserResponse> Login(LoginApplicationUserRequest request);

    }
}
