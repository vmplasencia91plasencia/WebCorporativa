using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCujae.Models
{
    public class Coordinate
    {
        [Key]
        public int CoordinateId { get; set; }
        [Required]
        [Display(Name = "nombre completo")]
        public string name { get; set; }
        [Required]
        [Display(Name = "telefono")]
        public string phone { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "correo")]
        public string mail { get; set; }
        public virtual Specialty Specialty { get; set; }
    }
}