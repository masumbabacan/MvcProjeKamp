using Business.Abstract;
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
        //ContentManager contentManager = new ContentManager(new EfContentDal());

        IContentService _contentService;

        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string p)
        {
            var getAllList = _contentService.GetAllList();
            var result = _contentService.GetAll(p);
            if (result == null)
            {
                return View(getAllList);
            }
            return View(result);
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentvalues = _contentService.GetAllByHeadingId(id);
            return View(contentvalues);
        }
    }
}