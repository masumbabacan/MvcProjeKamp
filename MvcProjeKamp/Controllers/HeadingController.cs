using Business.Concrete;
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
    public class HeadingController : Controller
    {
        //HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        //WriterManager writerManager = new WriterManager(new EfWriterDal());
        //CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        ICategoryService _categoryService;
        IWriterService _writerService;
        IHeadingService _headingService;

        public HeadingController(ICategoryService categoryService, IWriterService writerService, IHeadingService headingService)
        {
            _categoryService = categoryService;
            _writerService = writerService;
            _headingService = headingService;
        }

        public ActionResult Index()
        {
            var headingValues = _headingService.GetAll();
            return View(headingValues);
        }

        public ActionResult HeadingReport()
        {
            var headingValues = _headingService.GetAll();
            return View(headingValues);
        }


        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> valueCategory = (from c in _categoryService.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = c.CategoryName,
                                                      Value = c.CategoryId.ToString()
                                                  }).ToList();

            List<SelectListItem> valueWriter = (from w in _writerService.GetAll()
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
            _headingService.Add(heading);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {

            List<SelectListItem> valueCategory = (from c in _categoryService.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = c.CategoryName,
                                                      Value = c.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;

            var headingValue = _headingService.GetById(id);
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult Update(Heading heading)
        {
            _headingService.Update(heading);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {

            var headingValue = _headingService.GetById(id);
            if (headingValue.HeadingStatus == true)
            {
                headingValue.HeadingStatus = false;
            }
            else
            {
                headingValue.HeadingStatus = true;
            }
            _headingService.Delete(headingValue);
            return RedirectToAction("Index");
        }
    }
}