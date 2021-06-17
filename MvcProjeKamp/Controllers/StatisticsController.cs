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
    public class StatisticsController : Controller
    {

        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        // GET: Statistics
        Context _context = new Context();
        public ActionResult GetAll()
        {
            var categoryCount = categoryManager.GetAll().Count(); //Toplam Kategori Sayisi
            ViewBag.totalNumberOfCategories = categoryCount;

            var numberofsoftwaretitles = _context.Headings.Count(c => c.CategoryId == 19); //Toplam Kategori Sayisi
            ViewBag.softwaretitles = numberofsoftwaretitles;

            var authorNameStartingWithA = _context.Writers.Count(c => c.WriterName.Contains("a")); // Yazar adinda "a" harfi gecen yazar sayisi
            ViewBag.authorNameStartingWithA = authorNameStartingWithA;

            var categoryWithTheMostTitles = _context.Headings.Max(c => c.Category.CategoryName); // Yazar adinda "a" harfi gecen yazar sayisi
            ViewBag.categoryWithTheMostTitles = categoryWithTheMostTitles;

            var categoriesThatAreTrue = _context.Categories.Count(c => c.CategoryStatus==true); // Yazar adinda "a" harfi gecen yazar sayisi
            ViewBag.categoriesThatAreTrue = categoriesThatAreTrue;

            return View();
        }
    }
}