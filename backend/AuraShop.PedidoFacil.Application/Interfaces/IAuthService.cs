using AuraShop.PedidoFacil.Application.Dtos.Request;

namespace AuraShop.PedidoFacil.Application.Interfaces
{
    public interface IAuthService
    {
        public Task<bool> Register(RegisterApplicationUserRequest request);

        public Task<bool> Login(LoginApplicationUserRequest request);

    }
}
