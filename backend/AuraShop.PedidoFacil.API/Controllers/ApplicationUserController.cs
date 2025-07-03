using AuraShop.PedidoFacil.Application.Dtos.Request;
using AuraShop.PedidoFacil.Application.Dtos.Response;
using AuraShop.PedidoFacil.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuraShop.PedidoFacil.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IAuthService _auth;

        public ApplicationUserController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("/register")]
        [ProducesResponseType
            (typeof(RegisterApplicationUserRequest), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create
            ([FromBody]RegisterApplicationUserRequest dto)
        {
            bool success = await _auth.Register(dto);

            if (!success) throw new ArgumentException
                    ("A senha deve possuir ao menos 1 caractere numérico!");

            return Created("", dto);
        }

        [HttpPost("/login")]
        [ProducesResponseType
            (typeof(LoginApplicationUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login
            ([FromBody]LoginApplicationUserRequest dto)
        {
            var response = await _auth.Login(dto);

            return Ok(new 
            {
                response.Username,
                response.Role,
                response.Token
            });
        }
    }
}
