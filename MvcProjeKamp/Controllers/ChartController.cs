using Business.Concrete;
using DataAccess.EntityFramework;
using Entites.Concrete;
using MvcProjeKamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class ChartController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> category = new List<CategoryClass>();
            category.Add(new CategoryClass()
            {
                CategoryName = "Yazılım",
                CategoryCount = 9
            });
            category.Add(new CategoryClass()
            {
                CategoryName = "Kitap",
                CategoryCount = 7
            });
            category.Add(new CategoryClass()
            {
                CategoryName = "Tiyatro",
                CategoryCount = 5
            });
            category.Add(new CategoryClass()
            {
                CategoryName = "salda",
                CategoryCount = 5
            });
            return category;
        }
    }
}