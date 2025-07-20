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
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AuthService
            (IdentityContext context,
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Register(RegisterApplicationUserRequest request)
        {
            // Falta fazer a adição do role
            var user = _mapper.Map<ApplicationUser>(request);
            var result = await _userManager.CreateAsync(user, request.Password);

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
