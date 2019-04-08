using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace inz.Models
{
    public class File
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa pliku")]
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        [Display(Name = "Data ")]
        public DateTime Date { get; set; }
        [Display(Name = "Ścieżka do pliku")]
        public string Path { get; set; }

        public int? ProjectID { get; set; }
    }
}