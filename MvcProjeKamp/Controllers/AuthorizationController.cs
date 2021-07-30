using Business.Abstract;
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
        //AdminManager adminManager = new AdminManager(new EfAdminDal());

        IAdminService _adminService;

        public AuthorizationController(IAdminService adminService)
        {
            _adminService = adminService;
        }



        // GET: Authorization
        public ActionResult Index()
        {
            var adminValues = _adminService.GetAll();
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
            _adminService.Add(admin);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminValue = _adminService.GetById(id);
            return View(adminValue);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            _adminService.Update(admin);
            return RedirectToAction("Index");
        }
    }
}