using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCujae.Models
{
    public class Url
    {
        public int UrlId { get; set; }

        [Required]
        [Display(Name = "Url")]
        public string url { get; set; }

        public Event Event { get; set; }
    }
}