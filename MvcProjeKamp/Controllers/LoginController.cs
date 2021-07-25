using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace MvcProjeKamp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        AuthManager authManager = new AuthManager(new EfAdminDal(),new EfWriterDal());
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        SHA1 sha = new SHA1CryptoServiceProvider();

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            //admin.AdminPassword = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(admin.AdminPassword)));   | Hashleme işlemi businessda yapıldı burada ise çözme işlemini gerçekleştirdim. lakin şuan için kullanmayacağım o yüzden yorum satırı olarak kalsın :)
            var result = authManager.GetAdmin(admin.AdminUserName, admin.AdminPassword);
            
            if (result != null)
            {
                    FormsAuthentication.SetAuthCookie(result.AdminUserName, false);
                    Session["AdminUserName"] = result.AdminUserName;
                    return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult AdminRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminRegister(Admin admin)
        {
            adminManager.Add(admin);
            return RedirectToAction("Index");
        }


        //--------------------------------------------------------------------------------------------//
        //WRİTER


        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {

            var result = authManager.GetWriter(writer.WriterMail, writer.WriterPassword);
            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(result.WriterMail, false);
                Session["WriterMail"] = result.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("HomePage","Home");
            }
        }

        public ActionResult SuccessRegister()
        {
            return View();
        }

        [HttpGet]
        public ActionResult WriterRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterRegister(Writer writer)
        {
            writerManager.Add(writer);
            return RedirectToAction("SuccessRegister", "Login");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("HomePage", "Home");
        }

    }
}
