using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using urban100.Model;
using urban100.Web.Mail;
using urban100.Web.Models.ViewModels;

namespace urban100.Web.Areas.Default.Controllers
{
    public class HomeController : DefaultController
    {
        public ActionResult Index()
        {
            var list = Repository.Owners.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult AddPopup()
        {
            return View(new CandidateOwnerView());
        }

        [HttpPost]
        public ActionResult AddPopup(CandidateOwnerView candidateOwnerView)
        {
            if (string.IsNullOrWhiteSpace(candidateOwnerView.Email) &&
                string.IsNullOrWhiteSpace(candidateOwnerView.Phone))
            {
                ModelState.AddModelError("PhoneEmail", "");
            }
            if (ModelState.IsValid)
            {
                var candidate = (Candidate)ModelMapper.Map(candidateOwnerView, typeof(CandidateOwnerView), typeof(Candidate));

                Repository.CreateCandidate(candidate);

                if (candidateOwnerView.Ask == CandidateOwnerView.AskEnum.Interest)
                {
                    NotifyMail.SendNotify("CandidateInterest", Config.AdminEmail,
                        subject => string.Format(subject, candidate.Name),
                        body => string.Format(body, candidate.Name, candidate.Notes, candidate.Phone, candidate.Email));
                }
                if (candidateOwnerView.Ask == CandidateOwnerView.AskEnum.StrongInterest)
                {
                    NotifyMail.SendNotify("CandidateStrongInterest", Config.AdminEmail,
                        subject => string.Format(subject, candidate.Name),
                        body => string.Format(body, candidate.Name, candidate.Notes, candidate.Phone, candidate.Email));
                }

                return View("AddPopupSuccess");
            }
            return View(candidateOwnerView);
        }

        public ActionResult UserLogin()
        {
            return View(CurrentUser);
        }
    }
}