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
    public class HeadingController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        public ActionResult Index()
        {
            var headingValues = headingManager.GetAll();
            return View(headingValues);
        }

        public ActionResult HeadingReport()
        {
            var headingValues = headingManager.GetAll();
            return View(headingValues);
        }


        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> valueCategory = (from c in categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = c.CategoryName,
                                                      Value = c.CategoryId.ToString()
                                                  }).ToList();

            List<SelectListItem> valueWriter = (from w in writerManager.GetAll()
                                                select new SelectListItem
                                                {
                                                    Text = w.WriterName + " " + w.WriterSurName,
                                                    Value = w.WriterId.ToString()
                                                }).ToList();
            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valueWriter;

            return View();
        }

        [HttpPost]
        public ActionResult Add(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.Add(heading);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {

            List<SelectListItem> valueCategory = (from c in categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = c.CategoryName,
                                                      Value = c.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;

            var headingValue = headingManager.GetById(id);
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult Update(Heading heading)
        {
            headingManager.Update(heading);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {

            var headingValue = headingManager.GetById(id);
            if (headingValue.HeadingStatus == true)
            {
                headingValue.HeadingStatus = false;
            }
            else
            {
                headingValue.HeadingStatus = true;
            }
            headingManager.Delete(headingValue);
            return RedirectToAction("Index");
        }
    }
}