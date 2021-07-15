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
    public class LoginController : Controller
    {
        AuthManager authManager = new AuthManager(new EfAdminDal());
        AdminManager adminManager = new AdminManager(new EfAdminDal());
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
    }
}