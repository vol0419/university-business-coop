using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace inz.Models
{
    public class Agent
    {
        public int ID { get; set; }
        [Display(Name = "Imię i nazwisko")]
        public string Name { get; set; }
      
        public string Title { get; set; }
        [Display(Name = "Email")]
        public string Mail { get; set; }
        [Display(Name = "Numer telefonu")]
        public int Phone { get; set; }
        [Display(Name = "Pokój")]
        public string Place { get; set; }
        public string ImgName { get; set; }

        public string UserID { get; set; }
    }
}