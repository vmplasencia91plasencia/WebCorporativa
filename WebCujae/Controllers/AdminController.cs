﻿using System;
using System.Web;
using System.Web.Mvc;
using WebCujae.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.ModelBinding;

namespace WebCujae.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }
        private ApplicationRoleManager roleManager;


        public AdminController()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        }

        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        // POST: /Admin/Index/5
        public ActionResult Index(string notice)
        {
            ViewBag.Notice = notice;
            return View();
        }
        
        [HttpGet]
        public ActionResult AdminEvento()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult AdminEvento(Event even, IEnumerable<HttpPostedFileBase> files)
        {
            if (ModelState.IsValid)
            {
                List<Url> Urls = new List<Url>();
                
                foreach (var file in files)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        string archivo = Server.MapPath("~/Content/files/Uploads/" + (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + file.FileName).ToLower());
                        Url url = new Url() { url = archivo };
                        file.SaveAs(archivo);
                        Urls.Add(url);                     
                    }
                }
                even.Urls = Urls;
                ApplicationDbContext applicationDb = new ApplicationDbContext();
                applicationDb.Event.Add(even);
                applicationDb.SaveChanges();
                ApplicationDbContext.Dispose();
                return RedirectToAction("AdminEvento");
            }
                return View();
        }

        public ActionResult AdminListEvent()
        {
            ApplicationDbContext applicationDb = new ApplicationDbContext();
            List<Event> result = new List<Event>();
            result = applicationDb.Event.OrderBy(item => item.time).ToList();
            applicationDb.Dispose();
            return View(result);
        }

        public ActionResult DeleteEvent(int id)
        {
            ApplicationDbContext applicationDb = new ApplicationDbContext();
            Event result = applicationDb.Event.Find(id);
            //result.Urls.ToList();
            //List<Url> urls = applicationDb.Url.Where(url => url.Event.EventId == id).ToList();
           // result.Urls = urls;
            applicationDb.Event.Remove(result);
            applicationDb.SaveChanges();
            ApplicationDbContext.Dispose();
            return RedirectToAction("AdminListEvent");
        }

        public ActionResult AdminPregrado()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AdminPregrado(CKEditors editors)
        {
            string text = editors.data;
            //ViewData["data"] = text;
            Session["data"] = text;
            return RedirectToAction("Pregrado", "Home");
        }

        [HttpPost]
        public ActionResult File(HttpPostedFileBase file)
        {
            if (file == null)
                return null;
            string archivo = (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + file.FileName).ToLower();
            file.SaveAs(Server.MapPath("~/Content/img/Uploads/" + archivo));
            return RedirectToAction("Index", "Admin");
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Index(CKEditors editors)
        {
            string text2 = editors.noticias;
            string text1 = editors.data;
            Session["noticias"] = text2;
            Session["data"] = text1;
            return RedirectToAction("Index", "Admin", new { notice = "Datos Guardados exitosamente!!!!!" });
        }

        // GET: /Admin/Role
        [HttpGet]
        public ActionResult AdminRole()
        {
            List<RolesViewModels> list = new List<RolesViewModels>();
            ApplicationDbContext dbContext = new ApplicationDbContext();
            foreach (var i in dbContext.Users.ToList())
            {
                List<string> roleName = new List<string>();
                foreach (var j in i.Roles.ToList())
                {
                    if (i.Roles.Count != 0)
                        roleName.Add(ApplicationRoleManager.GetRoleNameById(j.RoleId));
                }
                if (i.UserName != "admin")
                {
                    list.Add(new RolesViewModels()
                    {
                        userId = i.Id,
                        Username = i.UserName,
                        roleName = roleName

                    });
                }
            }
            return View(list);
        }

        [HttpGet]
        public ActionResult EditRole(string id)
        {
            ApplicationUser user = UserManager.FindById(id);
            ViewBag.Description = user.Name + " " + user.LastName;
            var roleUser = user.Roles;
            if (roleUser.Count != 0)
                ViewBag.Name = ApplicationRoleManager.GetRoleNameById(roleUser.FirstOrDefault().RoleId);
            else
                ViewBag.Name = null;
            return View();
        }
        [HttpPost]
        public ActionResult EditRole(string id, RoleName role)
        {
            ApplicationUser user = UserManager.FindById(id);
            ViewBag.NameFull = user.Name + " " + user.LastName;
            if (ModelState.IsValid)
            {
                ApplicationDbContext contexto = new ApplicationDbContext();
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(contexto));
                user.Roles.Clear();
                UserManager.Update(user);
                manager.AddToRole(user.Id, role.name);
                return RedirectToAction("AdminRole");
            }

            return View();
        }
        [HttpGet]
        public ActionResult AdminAddMaestrias()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminAddMaestrias(Specialty model)
        {
            ApplicationUser data = UserManager.FindById(CurrentUser.Get.UserId);
            if (ModelState.IsValid)
            {
                using (var context = new ApplicationDbContext())
                {
                    Specialty specialty = new Specialty()
                    {
                        name = model.name,
                        zone = model.zone,
                        type = model.type,
                        actualizacion = DateTime.Today,
                        category = model.category,
                        creacion = model.creacion,
                        nameCoordinador = model.name,
                        phoneCoordinador = model.phoneCoordinador,
                        mailCoordinador = model.mailCoordinador,
                        UserId = data.Id,
                    };
                    context.Specialty.Add(specialty);
                    context.SaveChanges();
                    context.Dispose();
                }
            }

            return RedirectToAction("AdminListMaestrias");
        }
        public ActionResult AdminListMaestrias()
        {
            ApplicationDbContext applicationDb = new ApplicationDbContext();
            List<Specialty> Listado = applicationDb.Specialty.ToList();
            applicationDb.Dispose();
            return View(Listado);
        }

        public ActionResult DeleteMaestriasEspecialidad(int id)
        {
            ApplicationDbContext applicationDb = new ApplicationDbContext();
            Specialty result = applicationDb.Specialty.Find(id);
            applicationDb.Specialty.Remove(result);
            applicationDb.SaveChanges();
            ApplicationDbContext.Dispose();
            return RedirectToAction("AdminListMaestrias");
        }
        public ActionResult EditMaestriaEspecialidad(int id)
        {
            ApplicationDbContext applicationDb = new ApplicationDbContext();
            Specialty result = applicationDb.Specialty.Find(id);
            applicationDb.Specialty.Remove(result);
            applicationDb.SaveChanges();
            ApplicationDbContext.Dispose();
            return View(result);
        }
        [HttpGet]
        public ActionResult addPremios()
        {

            return View();
        }
        [HttpPost]
        public ActionResult addPremios(Award model)
        {
            if (ModelState.IsValid)
            {
                Award newaward = new Award()
                {
                    name = model.name,
                    año = model.año,
                    facultad = model.facultad,
                    autores = model.autores
                };
                ApplicationDbContext applicationDb = new ApplicationDbContext();
                applicationDb.Award.Add(newaward);
                applicationDb.SaveChanges();
                ApplicationDbContext.Dispose();
            }
            return View();

        }
        [HttpGet]
        public ActionResult ListPremios()
        {
            ApplicationDbContext applicationDb = new ApplicationDbContext();
            List<Award> result = new List<Award>();
            result=applicationDb.Award.ToList();
            applicationDb.Dispose();
            return View(result);
        }
        public ActionResult DeletePremio(int id)
        {
            ApplicationDbContext applicationDb = new ApplicationDbContext();
            Award result = applicationDb.Award.Find(id);
            applicationDb.Award.Remove(result);
            applicationDb.SaveChanges();
            ApplicationDbContext.Dispose();
            return RedirectToAction("ListPremios");
        }

        public ActionResult EditPremio(int id)
        {
            ApplicationDbContext applicationDb = new ApplicationDbContext();
            Award result = applicationDb.Award.Find(id);
            applicationDb.Award.Remove(result);
            applicationDb.SaveChanges();
            ApplicationDbContext.Dispose();
            return View(result);
        }

        public ActionResult AdminComunidadUniversitaria()
        {
            return View();
        }
    }
}