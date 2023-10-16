using System.ComponentModel.DataAnnotations;

namespace TaskPlanner.ViewModels
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O Nome deve conter no mínimo 3 caracteres.")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "O Sobrenome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O Sobrenome deve conter no mínimo 3 caracteres.")]
        public string LastName { get; set; } = null!;
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "O Email é obrigatório.")]
        public string Email { get; set; } = null!;
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "A Senha é obrigatória.")]
        [MinLength(6, ErrorMessage = "A senha deve conter no mínimo 6 caracteres.")]
        public string Password { get; set; } = null!;
        [Compare("Password", ErrorMessage = "As senhas não são iguais.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
