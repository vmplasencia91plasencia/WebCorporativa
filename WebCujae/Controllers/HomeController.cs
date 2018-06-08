using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCujae.Models;

namespace WebCujae.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }
        public ActionResult Index()
        {
            return View();
        }
  
        public ActionResult Pregrado()
        {
            return View();
        }

        public ActionResult Eventos()
        {
            return View();
        }
        public ActionResult Noticias()
        {
            return View();
        }
        public ActionResult Universidad()
        {
            return View();
        }
        public ActionResult Maestrias()
        {
            ApplicationDbContext applicationDb = new ApplicationDbContext();
            List<Specialty> Listado = applicationDb.Specialty.ToList();
            applicationDb.Dispose();
            foreach (var i in Listado)
            {
                if (i.type.Equals("especialidad"))
                {
                    Listado.Remove(i);
                }
            }

            return View(Listado);
        }
        public ActionResult Especialidades()
        {
            ApplicationDbContext applicationDb = new ApplicationDbContext();
            List<Specialty> Listado = applicationDb.Specialty.ToList();
            applicationDb.Dispose();
            foreach (var i in Listado)
            {
                if (i.type.Equals("maestria"))
                {
                    Listado.Remove(i);
                }
            }
           
            return View(Listado);
        }
    }
}