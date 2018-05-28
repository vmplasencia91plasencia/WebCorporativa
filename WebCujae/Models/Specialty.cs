using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebCujae.Models
{
    public class Specialty
    {
        [Key]
        public int SpecialtyId { get; set; }

        public string UserId { get; set; }

        [Required]
        [Display(Name ="Área")]
        public string zone { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        public string type { get; set; }

        public DateTime actualizacion { get; set; }

        [Required]
        [Display(Name = "Fecha de creación")]
        public string creacion { get; set; }

        [Required]
        [Display(Name = "categoría")]
        public string category { get; set; }

        [Required]
        [Display(Name = "Nombre del coordinador")]
        public string nameCoordinador { get; set; }

        [Required]
        [Display(Name = "Teléfono del coordinador")]
        public string phoneCoordinador { get; set; }

        [Required]
        [Display(Name = "Correo del coordinador")]
        [EmailAddress]
        public string mailCoordinador { get; set; }

    }
}