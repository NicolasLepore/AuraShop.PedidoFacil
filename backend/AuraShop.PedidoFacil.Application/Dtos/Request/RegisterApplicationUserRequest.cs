using AuraShop.PedidoFacil.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace AuraShop.PedidoFacil.Application.Dtos.Request
{
    public class RegisterApplicationUserRequest
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Compare("Password")]
        public string RePassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string RoleName { get; set; } = string.Empty;
    }
}
