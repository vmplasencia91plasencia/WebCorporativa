using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCujae.Models
{
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole, string> roleStore)
            : base(roleStore)
        {

        }

        public static IdentityRole CreateAdminRole()
        {
            var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var applicationRoleAdministrator = new IdentityRole("admin");
            if (!roleManager.RoleExists(applicationRoleAdministrator.Name))
            {
                roleManager.Create(applicationRoleAdministrator);
                return applicationRoleAdministrator;
            }
            return roleManager.FindByName("admin");
        }

        public static String GetRoleNameById(string id)
        {
            var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            return roleManager.FindById(id).Name;
        }

        public static String GetRoleNameByName(string name)
        {
            var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            return roleManager.FindByName(name).Id;
        }

        public static bool AsingRoleUser(string userId,string roleId) {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            ApplicationUser user=dbContext.Users.Find(userId);
            List<IdentityUserRole> result = user.Roles.ToList();
            dbContext.Dispose();
            foreach (var i in result)
            {
                if (i.RoleId.Equals(roleId))
                    break;
                    return true;
            }
            return false;
        }

        public static void CreateRole()
        {
            var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            if (!roleManager.RoleExists("redactor") && !roleManager.RoleExists("revisor")&& !roleManager.RoleExists("investigador"))
            {
                var applicationRoleRedactor = new IdentityRole("redactor");
                var applicationRevisor = new IdentityRole("revisor");
                var applicationInvestigador = new IdentityRole("investigador");
                roleManager.Create(applicationRevisor);
                roleManager.Create(applicationRoleRedactor);
                roleManager.Create(applicationInvestigador);

            }
        }
          

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            ApplicationDbContext conte = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(conte));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(conte));
            //return new ApplicationRoleManager(new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>()));
            return new ApplicationRoleManager(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        }
    }
}