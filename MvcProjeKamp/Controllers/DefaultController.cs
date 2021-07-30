using Business.Abstract;
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
       // HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
       // ContentManager contentManager = new ContentManager(new EfContentDal());

        IContentService _contentService;
        IHeadingService _headingService;
        public DefaultController(IContentService contentService, IHeadingService headingService)
        {
            _contentService = contentService;
            _headingService = headingService;
        }

        [AllowAnonymous]
        public ActionResult Headings()
        {
            var result = _headingService.GetAll();
            return View(result);
        }
        [AllowAnonymous]
        public PartialViewResult Index(int id = 0)
        {
            var result = _contentService.GetAllByHeadingId(id);
            return PartialView(result);
        }
    }
}