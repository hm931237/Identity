using ASPNETIdentity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPNETIdentity.Startup))]
namespace ASPNETIdentity
{
    public partial class Startup
    {
        ApplicationDbContext Db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRules();
            CreateUsers();
        }
        public void CreateRules()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(Db));
            IdentityRole Role = new IdentityRole();
            if (!roleManager.RoleExists("Admins"))
            {
                Role.Name = "Admins";
                roleManager.Create(Role);
            }
        }

        public void CreateUsers()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(Db));
            var User = new ApplicationUser();
            User.Email = "hm931237@gmail.com";
            User.UserName = "Hesham";
            
            var Check = userManager.Create(User,"Hesh@m123");
            if (Check.Succeeded)
            {
                userManager.AddToRole(User.Id, "Admins");
            }
        }
    }
}
