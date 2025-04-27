using AuraShop.PedidoFacil.Application.Dtos.Request;
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

        [HttpPost]
        [ProducesResponseType
            (typeof(RegisterApplicationUserRequest), StatusCodes.Status201Created)]
        [ProducesResponseType
            (typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create
            ([FromBody]RegisterApplicationUserRequest dto)
        {
            bool success = await _auth.Register(dto);

            if (!success) throw new ArgumentException
                    ("A senha deve possuir ao menos 1 caractere numérico!");

            return Created("", dto);
        }
    }
}
