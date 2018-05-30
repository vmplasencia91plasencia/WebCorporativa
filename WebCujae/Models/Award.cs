using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebCujae.Models
{
    public class Award
    {
        [Key]
        public int AwardId { get; set; }

        public string UserId { get; set; }

        [Required]
        [Display(Name ="Nombre")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Autores")]
        public string autores { get; set; }

        [Required]
        [Display(Name = "Año")]
        public string año { get; set; }

        [Required]
        [Display(Name = "Facultad")]
        public string facultad { get; set; }



    }
}