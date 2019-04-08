using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace inz.Models
{
    public class Uph_offer
    {
        public int ID { get; set; }
        [Display(Name = "Tytuł oferty")]
        public string Title { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }

        public string ImgName { get; set; }
        [Display(Name = "Data")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime Date { get; set; }
        [Display(Name = "Autor")]
        public string Author { get; set; }
        [Display(Name = "Wydział")]
        public string Department { get; set; }
        [Display(Name = "Dodatkowa informacja")]
        public string  Aiddtional_information{ get; set; }
        public virtual List<Category> Categories { get; set; }
    }
}