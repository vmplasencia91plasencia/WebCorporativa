using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebCujae.Models
{
    public class Site
    {
        [Key]
        public int SiteID { get; set; }
        public string name { get; set; }


        public virtual ICollection<Data> Datas { get; set; }
        public virtual Undergraduate Undergraduate { get; set; }
        //public virtual Specialty Specialty { get; set; }
    }
}
