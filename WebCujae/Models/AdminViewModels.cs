using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCujae.Models
{
    public class RolesViewModels 
    {
        public string userId { get; set; }
        public string Username { get; set; }
        public List<String> roleName{ get; set; }
    }
}