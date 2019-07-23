using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reservas.Models
{
  
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Endereço eletrónico")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Endereço eletrónico")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Palavra passe")]
        public string Password { get; set; }

        [Display(Name = "Lembrar nome de utilizador")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Endereço eletrónico")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} tem que ter pelo menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Palavra passe")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Palavra passe")]
        [Compare("Password", ErrorMessage = "As palavras passes são diferentes!")]
        public string ConfirmPassword { get; set; }

        public string Fotografia { get; set; }

        public Tecnicos tecnicos { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correio eletrónico")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} tem que ter pelo menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Palavra passe")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar palavra passe")]
        [Compare("Password", ErrorMessage = "As palavras passes são diferentes!")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}