using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using urban100.Web.Mail;

namespace urban100.Web.Areas.Admin.Controllers
{
    public class TestController : AdminController
    {
        public ActionResult Index()
        {
            var mailSender = new MailSender();

            mailSender.SendMail("chernikov@gmail.com", "Test", "Test");
            return Content("OK");
        }
	}
}