using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace urban100.Web.Areas.Default.Controllers
{
    public class HomeController : DefaultController
    {
        public ActionResult Index()
        {
            var list = Repository.Owners.ToList();
            return View(list);
        }

        public ActionResult UserLogin()
        {
            return View(CurrentUser);
        }
    }
}