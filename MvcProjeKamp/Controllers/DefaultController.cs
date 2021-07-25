using Business.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());

        [AllowAnonymous]
        public ActionResult Headings()
        {
            var result = headingManager.GetAll();
            return View(result);
        }
        [AllowAnonymous]
        public PartialViewResult Index(int id = 0)
        {
            var result = contentManager.GetAllByHeadingId(id);
            return PartialView(result);
        }
    }
}