using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaContactRegistration.Api.Models.Account
{
    public class RegisterContactModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}