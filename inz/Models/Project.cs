using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace inz.Models
{
    public class Project
    {
        public int ID { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
       
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [Display(Name = "Data początkowa")]
        public DateTime Start_date { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [Display(Name = "Data końcowa ")]
        public DateTime End_date { get; set; }
        [Display(Name = "Temat projektu ")]
        [DataType(DataType.MultilineText)]
        public string desc { get; set; }
        public string test { get; set; }
        public List<string> Users { get; set; }

        public string Mails { get; set; }

        public virtual List<Quest> Tasks { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<File> Files { get; set; }
    }
}