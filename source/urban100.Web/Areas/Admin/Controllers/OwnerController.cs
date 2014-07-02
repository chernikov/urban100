using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using urban100.Web.Models.ViewModels;
using urban100.Model;


namespace urban100.Web.Areas.Admin.Controllers
{ 
    public class OwnerController : AdminController
    {
		public ActionResult Index()
        {
			var list = Repository.Owners.ToList();
			return View(list);
		}

		public ActionResult Create() 
		{
			var ownerView = new OwnerView();
			return View("Edit", ownerView);
		}

		[HttpGet]
		public ActionResult Edit(int id) 
		{
			var  owner = Repository.Owners.FirstOrDefault(p => p.ID == id); 

			if (owner != null) {
				var ownerView = (OwnerView)ModelMapper.Map(owner, typeof(Owner), typeof(OwnerView));
				return View(ownerView);
			}
			return RedirectToNotFoundPage;
		}

		[HttpPost]
		public ActionResult Edit(OwnerView ownerView)
        {
            if (ModelState.IsValid)
            {
                var owner = (Owner)ModelMapper.Map(ownerView, typeof(OwnerView), typeof(Owner));
                if (owner.ID == 0)
                {
                    Repository.CreateOwner(owner);
                }
                else
                {
                    Repository.UpdateOwner(owner);
                }
                return RedirectToAction("Index");
            }
            return View(ownerView);
        }

        public ActionResult Delete(int id)
        {
            var owner = Repository.Owners.FirstOrDefault(p => p.ID == id);
            if (owner != null)
            {
                    Repository.RemoveOwner(owner.ID);
            }
			return RedirectToAction("Index");
        }
	}
}