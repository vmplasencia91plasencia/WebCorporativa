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
        public int zone { get; set; }
        public string name { get; set; }
        public virtual ICollection<Coordinate> Coordinates { get; set; }
        public DateTime actualizacion { get; set; }
        public string category { get; set; }

        public virtual Site Site { get; set; }
    }
}