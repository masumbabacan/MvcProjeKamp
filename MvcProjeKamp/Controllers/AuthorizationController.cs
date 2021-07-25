using Business.Concrete;
using DataAccess.EntityFramework;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        // GET: Authorization
        public ActionResult Index()
        {
            var adminValues = adminManager.GetAll();
            return View(adminValues);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            adminManager.Add(admin);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminValue = adminManager.GetById(id);
            return View(adminValue);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            adminManager.Update(admin);
            return RedirectToAction("Index");
        }
    }
}