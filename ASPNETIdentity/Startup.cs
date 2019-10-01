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
    }
}
