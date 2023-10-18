using System.ComponentModel.DataAnnotations;

namespace TaskPlanner.ViewModels
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress, ErrorMessage = "Digite um Email válido.")]
        [Required(ErrorMessage = "Digite seu Email.")]
        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Digite sua Senha.")]
        public string Password { get; set; } = null!;

        public bool Remember { get; set; }
    }
}
