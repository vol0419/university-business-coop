using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace inz.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Display(Name = "Nazwa Kategorii")]
        public string Name { get; set; }
    }
}