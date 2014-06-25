using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using urban100.Web.Validation;

namespace urban100.Web.Models.ViewModels.User
{
    public class ForgotPasswordView
    {
        [Required(ErrorMessage = "Enter Email")]
        [ValidEmail(ErrorMessage = "Enter correct Email")]
        public string Email { get; set; }
    }
}