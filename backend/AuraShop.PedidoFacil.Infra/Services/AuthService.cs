using AuraShop.PedidoFacil.Application.Dtos.Request;
using AuraShop.PedidoFacil.Infra.Identity.Models;
using AuraShop.PedidoFacil.Infra.Identity;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using AuraShop.PedidoFacil.Application.Interfaces;
using AuraShop.PedidoFacil.Domain.Enums;

namespace AuraShop.PedidoFacil.Infra.Services
{
    public class AuthService : IAuthService
    {
        private readonly IdentityContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService
            (IdentityContext context,
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Register(RegisterApplicationUserRequest request)
        {
            var user = _mapper.Map<ApplicationUser>(request);
            var result = await _userManager.CreateAsync(user, request.Password);

            if(Enum.TryParse<RoleEnum>(request.RoleName, true, out var role)) 
            {
                await _userManager.AddToRoleAsync(user, role.ToString());
            }
            else
            {
                await _userManager.AddToRoleAsync(user, RoleEnum.User.ToString());
            }

            return result.Succeeded;
        }

        public async Task<bool> Login(LoginApplicationUserRequest request)
        {
            // Mudar login para ser com o EMAIL ao inves do Username
            var result = await _signInManager.PasswordSignInAsync
                (request.Username, request.Password, 
                isPersistent: true, lockoutOnFailure: true);

            if (result.IsLockedOut) throw new ApplicationException("Tentativas de login excedidas, tente novamente em 3 minutos.");

            return result.Succeeded;
        }
    }
}
