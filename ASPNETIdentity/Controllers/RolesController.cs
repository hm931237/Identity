using ASPNETIdentity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNETIdentity.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        ApplicationDbContext Db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }
        //Create Role
        public ActionResult Create(Role role)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(Db));
            IdentityRole Role = new IdentityRole();
            if (!roleManager.RoleExists(role.Name))
            {
                Role.Name = role.Name;
                roleManager.Create(Role);
            }
            return Content("Done");
        }

        public ActionResult ShowRoles()
        {
            return View(Db.Roles.ToList());
        }
    }
}