using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entites.Concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();
        Context context = new Context();

        [HttpGet]
        public ActionResult WriterProfile(int id = 0)
        {
            string p = (string)Session["WriterMail"];
            id = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var writerValue = writerManager.GetById(id);
            return View(writerValue);
        }


        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                writerManager.Update(writer);
                return RedirectToAction("AllHeading/WriterPanel");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult MyHeading(string p)
        {

            p = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var value = headingManager.GetAllByWriter(writerIdInfo);
            return View(value);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {

            List<SelectListItem> valueCategory = (from c in categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = c.CategoryName,
                                                      Value = c.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string p = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();

            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = writerIdInfo;
            heading.HeadingStatus = true;
            headingManager.Add(heading);
            return RedirectToAction("MyHeading");
        }



        [HttpGet]
        public ActionResult EditHeading(int id)
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
        public ActionResult EditHeading(Heading heading)
        {
            headingManager.Update(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
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
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading(int p = 1)
        {

            var result = headingManager.GetAll().ToPagedList(p,4);
            return View(result);
        }
    }
}


