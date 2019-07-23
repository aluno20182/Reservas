using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reservas.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public bool BrowserRemembered { get; set; }

        public string Fotografia { get; set; }
    }


    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Palavra Passe Atual")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} tem que ter pelo menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Palavra Passe")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar nova Palavra Passe")]
        [Compare("NewPassword", ErrorMessage = "A nova Palavra Passe e a sua confirmação não são iguais.")]
        public string ConfirmPassword { get; set; }
    }
}