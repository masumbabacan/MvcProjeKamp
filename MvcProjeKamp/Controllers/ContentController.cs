using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager contentManager = new ContentManager(new EfContentDal());

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string p)
        {
            var getAllList = contentManager.GetAllList();
            var result = contentManager.GetAll(p);
            if (result == null)
            {
                return View(getAllList);
            }
            return View(result);
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentvalues = contentManager.GetAllByHeadingId(id);
            return View(contentvalues);
        }
    }
}