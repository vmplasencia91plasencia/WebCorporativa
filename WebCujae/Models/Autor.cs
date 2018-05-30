using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCujae.Models
{
    public class Autor
    {
        [Key]
        public int AutorId { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string name { get; set; }
    }
}