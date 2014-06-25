using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using urban100.Web.Validation;

namespace urban100.Web.Models.ViewModels.User
{
    [PropertiesMustMatch("Password", "ConfirmPassword", ErrorMessage = "Password doesn't match")]
    public class RegisterUserView : BaseUserView
    {
        [Required(ErrorMessage = "Enter Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password error")]
        [Compare("Password", ErrorMessage = "Password doesn't match")]
        public string ConfirmPassword { get; set; }

        public string Captcha { get; set; }
    }
}