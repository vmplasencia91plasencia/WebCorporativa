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
        public string name { get; set; }
        public string phone { get; set; }
        public string mail { get; set; }
        public virtual Specialty Specialty { get; set; }
    }
}