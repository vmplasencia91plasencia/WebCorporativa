using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCujae.Models
{
    public class Specialty
    {
        [Key]
        public int SpecialtyId { get; set; }
        //public int ApplicationUserId { get; set; }
        [Required]
        [Display(Name ="area")]
        public int zone { get; set; }
        [Required]
        [Display(Name = "nombre")]
        public string name { get; set; }
        [Required]
        [Display(Name = "tipo")]
        public string type { get; set; }
       
        [Required]
        [Display(Name = "actualización")]
        public DateTime actualizacion { get; set; }
        [Required]
        [Display(Name = "categoria")]
        public string category { get; set; }

      
        public virtual Coordinate Coordinate { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}