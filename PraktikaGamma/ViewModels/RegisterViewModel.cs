using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PraktikaGamma.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Это поле не должно быть пустым")]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Это поле не должно быть пустым")]
        [StringLength(100, ErrorMessage = "{0} должty иметь минимум {2} и максимум {1} символов.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Это поле не должно быть пустым")]
        [Compare("Password", ErrorMessage = "Пароль не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}
