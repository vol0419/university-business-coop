using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace inz.Models
{
    public class Comment
    {
        public int ID { get; set; }

        [StringLength(500, MinimumLength = 1, ErrorMessage = "Komentarz musi mieć od 1 do 500 znaków.")]
        [Display(Name = "Treść komentarza")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Nick")]
        public string Nickname { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        [Display(Name = "Data dodania")]
        public DateTime Date { get; set; }

        public int? ProjectID { get; set; }
        public int? QuestID { get; set; }

    }
}