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
    public class AboutController : Controller
    {
        // GET: About

        //AboutManager aboutManager = new AboutManager(new EfAboutDal());

       IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public ActionResult Index()
        {
            var aboutValues = _aboutService.GetAll();
            return View(aboutValues);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(About about)
        {
            _aboutService.Add(about);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

        public ActionResult Delete(int id)
        {
            var aboutValue = _aboutService.GetById(id);
            if (aboutValue.Status == true)
            {
                aboutValue.Status = false;
            }
            else
            {
                aboutValue.Status = true;
            }
            _aboutService.Delete(aboutValue);
            return RedirectToAction("Index");
        }
    }
}