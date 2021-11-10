using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.EntityFramework;
using Entites.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class AdminCategoryController : Controller
    {
        //CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        ICategoryService _categoryService;

        public AdminCategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Authorize]
        public ActionResult Index()
        {
            var categoryvalues = _categoryService.GetAll();
            return View(categoryvalues);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category category) 
        {
            CategoryValidator validations = new CategoryValidator();
            ValidationResult result = validations.Validate(category);
            if (result.IsValid)
            {
                _categoryService.Add(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }


        public ActionResult Delete(int id)
        {
            var categoryvalue = _categoryService.GetById(id);
            _categoryService.Delete(categoryvalue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var categoryvalue = _categoryService.GetById(id);
            return View(categoryvalue);
        }

        [HttpPost]
        public ActionResult Update(Category category)
        {
            _categoryService.Update(category);
            return RedirectToAction("Index");
        }
    }
}