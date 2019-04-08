using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace inz.Models
{
    public class Quest
    {
        public int ID { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [Display(Name = "Data początkowa")]
        [DataType(DataType.Date)]
        public DateTime Start_date { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Data końcowa")]
        public DateTime End_date { get; set; }
        [Display(Name = "Treść zadania")]
        public string Desc { get; set; }
        [Display(Name = "Komentarze")]
        public virtual List<Comment> Comments { get; set; }

        public int? ProjectID { get; set; }
    }
}