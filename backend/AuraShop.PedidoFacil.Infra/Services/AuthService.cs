using AuraShop.PedidoFacil.Application.Dtos.Request;
using AuraShop.PedidoFacil.Infra.Identity.Models;
using AuraShop.PedidoFacil.Infra.Identity;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using AuraShop.PedidoFacil.Application.Interfaces;

namespace AuraShop.PedidoFacil.Infra.Services
{
    public class AuthService : IAuthService
    {
        private readonly IdentityContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthService(IdentityContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<bool> Register(RegisterApplicationUserRequest request)
        {
            var user = _mapper.Map<ApplicationUser>(request);
            var result = await _userManager.CreateAsync(user, request.Password);

            return result.Succeeded;
        }

        public async Task<bool> Login(LoginApplicationUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
