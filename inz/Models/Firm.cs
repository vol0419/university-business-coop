using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace inz.Models
{
    public class Firm
    {
        public int ID { get; set; }
        [Display(Name = "Nazwa firmy")]
        public string Name { get; set; }
        [Display(Name = "Adres")]
        public string Adress { get; set; }
        [Display(Name = "Email")]
        public string Mail { get; set; }
        [Display(Name = "Strona internetowa Firmy")]
        public string Www { get; set; }
        [Display(Name = "Numer telefonu")]
        public int Phone { get; set; }
        [Display(Name = "Zgoda")]
        public bool Consent { get; set; }

        public string UserID { get; set; }
    }
}