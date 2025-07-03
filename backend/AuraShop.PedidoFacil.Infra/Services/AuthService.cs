using AuraShop.PedidoFacil.Application.Dtos.Request;
using AuraShop.PedidoFacil.Infra.Identity.Models;
using AuraShop.PedidoFacil.Infra.Identity;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using AuraShop.PedidoFacil.Application.Interfaces;
using AuraShop.PedidoFacil.Application.Dtos.Response;

namespace AuraShop.PedidoFacil.Infra.Services
{
    public class AuthService : IAuthService
    {
        private readonly IdentityContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly TokenService _tokenService;

        public AuthService(IdentityContext context, IMapper mapper, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, TokenService tokenService)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<bool> Register(RegisterApplicationUserRequest request)
        {
            var user = _mapper.Map<ApplicationUser>(request);
            var result = await _userManager.CreateAsync(user, request.Password);

            return result.Succeeded;
        }

        public async Task<LoginApplicationUserResponse> Login(LoginApplicationUserRequest request)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);

            if (!result.Succeeded) throw new ArgumentException("Usuario ou senha incorretos");

            var user = _signInManager
                .UserManager
                .Users.FirstOrDefault(u => u.UserName == request.Username)!;

            var token = _tokenService.Generate(user);

            var userResponse = new LoginApplicationUserResponse()
            {
                Username = user.UserName!,
                Token = token,
                Role = "Member"
            };

            return userResponse;
        }
    }
}
