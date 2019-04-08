using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace inz.Models
{
    public class Polling  
    {
        public int ID { get; set; }
        [Display(Name = "Nazwa ")]
        public string Name { get; set; }
        [Display(Name = "link do formularza ")]
        public string FormLink { get; set; }

    }
}
 