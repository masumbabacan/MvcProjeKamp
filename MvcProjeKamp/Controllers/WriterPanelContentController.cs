using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Abstract;
namespace MvcProjeKamp.Controllers
{
    public class WriterPanelContentController : Controller
    {
        //ContentManager contentManager = new ContentManager(new EfContentDal());
        Context context = new Context();

        IContentService _contentService;

        public WriterPanelContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        public ActionResult MyContent(string p)
        {

            p = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var contentvalues = _contentService.GetAllByWriter(writerIdInfo);
            return View(contentvalues);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string mail = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterId = writerIdInfo;
            content.ContentStatus = true;
            _contentService.Add(content);
            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}