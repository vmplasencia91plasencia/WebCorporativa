using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCujae.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string description { get; set; }

        [Required]
        [Display(Name = "Fecha")]
        public DateTime time { get; set; }

        [Display(Name = "Recursos")]
        public ICollection<Url> Urls { get; set; }
    }
}