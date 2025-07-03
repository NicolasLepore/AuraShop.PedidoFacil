using System.ComponentModel.DataAnnotations;

namespace AuraShop.PedidoFacil.Application.Dtos.Request
{
    public class LoginApplicationUserRequest
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
