using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace inz.Models
{
    public class News
    {
        public int ID { get; set; }
        [Display(Name = "Tytuł artykułu")]
        public string Title { get; set; }
        [Display(Name = "Treść")]
        public string Description { get; set; }
        [Display(Name = "Data publikacji")]
        public DateTime Date { get; set; }
       
        [Display(Name = "Ocena")]
        public int Rating { get; set; }
        [Display(Name = "Liczba ocen")]
        public int RatingCount { get; set; }
        [Display(Name = "Autor")]
        public string Author { get; set; }
        public string ImgName { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}