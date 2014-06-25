﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using urban100.Web.Validation;

namespace urban100.Web.Models.ViewModels.User
{
    public class BaseUserView
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [ValidEmail(ErrorMessage = "Enter correct Email")]
        [UserEmailValidation(ErrorMessage = "Email already registered")]
        public string Email { get; set; }
    }
}