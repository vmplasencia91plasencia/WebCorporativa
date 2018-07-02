using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCujae.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }



        [Required(ErrorMessage = "Por favor introduzca el nombre del evento")]
        [Display(Name = "Nombre")]
        public string name { get; set; }

        [Required(ErrorMessage = "Por favor introduzca la descripción del evento")]
        [Display(Name = "Descripción")]
        [AllowHtml]
        public string description { get; set; }

        [Required(ErrorMessage = "Por favor especifique la fecha del evento")]
        [Display(Name = "Fecha")]
        public DateTime time { get; set; }

        [Display(Name = "Recursos")]
        public ICollection<Url> Urls { get; set; }
    }
}