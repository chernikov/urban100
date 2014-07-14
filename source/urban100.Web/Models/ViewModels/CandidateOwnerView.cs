using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using urban100.Web.Validation;

namespace urban100.Web.Models.ViewModels
{
    public class CandidateOwnerView
    {
        public enum AskEnum 
        {
            Interest = 0x01, 
            StrongInterest = 0x02
        }

        public AskEnum Ask { get; set; }

        [Required]
        public string Name { get; set; }

        [ValidPhone]
        public string Phone { get; set; }

        [ValidEmail]
        public string Email { get; set; }

        public string Notes { get; set; }

        public CandidateOwnerView()
        {
            Ask = AskEnum.StrongInterest;
        }
    }
}