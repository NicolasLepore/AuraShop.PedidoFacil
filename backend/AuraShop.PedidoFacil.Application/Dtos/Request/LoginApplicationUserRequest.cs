using System.ComponentModel.DataAnnotations;

namespace AuraShop.PedidoFacil.Application.Dtos.Request
{
    public class LoginApplicationUserRequest
    {
        public string Username { get; set; } = string.Empty;

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

    }
}
