using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace inz.Models
{
    public class OffersPending
    {

        public int Id { get; set; }
        [Display(Name = "Tytuł Oferty ")]
        public string Title { get; set; }
        [Display(Name = "Nadawca")]
        public string OfferFrom { get; set; }
        [Display(Name = "Odbiorca ")]
        public string Agent { get; set; }
        public bool Taken { get; set; }
        [Display(Name = "Wiadomość ")]
        public string Description { get; set; }

        public int OfferID { get; set; }
        public int? AgentID { get; set; }

    }
}