using System;
using System.Web;
using System.Web.Mvc;
using WebCujae.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace  WebCujae.Controllers
{
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
        [HttpGet]
        // POST: /Admin/Index/5
        public ActionResult Index(string notice)
        {
            if (CurrentUser.Get == null)
                return RedirectToAction("Login", "Account");
            ViewBag.Notice = notice;
            return View();
        }
        public ActionResult AdminEvento()
        {
            return View();
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
        public ActionResult EditRole(string id,RoleName role)
        {
            ApplicationUser user = UserManager.FindById(id);
            ViewBag.NameFull= user.Name + " " + user.LastName;
            if (ModelState.IsValid) {
                ApplicationDbContext contexto = new ApplicationDbContext();
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(contexto));
                user.Roles.Clear();
                UserManager.Update(user);
                manager.AddToRole(user.Id, role.name);
                return RedirectToAction("AdminRole");
            }

            return View();
        }
            
    }
}