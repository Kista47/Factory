using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PraktikaGamma.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Это поле должно быть заполнено")]
        [Display(Name = "Имя учетной записи")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Это поле должно быть заполнено")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}
