using Business.Abstract;
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
    public class GalleryController : Controller
    {
        // GET: Gallery
        //ImageFileManager imageFileManager = new ImageFileManager(new EfImageFileDal());
        IImageFileService _imageFileService;

        public GalleryController(IImageFileService imageFileService)
        {
            _imageFileService = imageFileService;
        }

        [Authorize]
        public ActionResult Index()
        {
            var files = _imageFileService.GetAll();
            return View(files);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ImageFile ımageFile)
        {
            _imageFileService.Add(ımageFile);
            return RedirectToAction("Index");
        }


    }
}
