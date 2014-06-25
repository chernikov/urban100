using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using urban100.Web.Mail;
using urban100.Web.Models.ViewModels;
using urban100.Web.Models.ViewModels.User;

namespace urban100.Web.Areas.Default.Controllers
{
    public class LoginController : DefaultController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new LoginView());
        }

        [HttpPost]
        public ActionResult Index(LoginView loginView)
        {
            if (ModelState.IsValid)
            {
                var user = Auth.Login(loginView.Email, loginView.Password, loginView.IsPersistent);
                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("Password", "Password doesn't match");
            }
            return View(loginView);
        }

        public ActionResult Logout()
        {
            Auth.LogOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View(new ForgotPasswordView());
        }

        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordView forgotPasswordView)
        {
            if (ModelState.IsValid)
            {
                var user =
                    Repository.Users.FirstOrDefault(p => string.Compare(p.Email, forgotPasswordView.Email, true) == 0);
                if (user != null)
                {
                    NotifyMail.SendNotify("ForgotPassword", user.Email,
                                                format => string.Format(format, HostName),
                                                format => string.Format(format, user.Email, user.Password, HostName));
                    return View("ForgotPasswordSuccess");
                }
                ModelState.AddModelError("Email", "Email user not found");
            }
            return View(forgotPasswordView);
        }
    }
}