using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraktikaGamma.ViewModels
{
    public class RolesLoginViewModel
    {
        public string Role { get; set; }
        public SignInResult Result { get; set; }

        public RolesLoginViewModel(string role, SignInResult result)
        {
            this.Role = role;
            this.Result = result;
        }
        public RolesLoginViewModel() { }
    }
}
