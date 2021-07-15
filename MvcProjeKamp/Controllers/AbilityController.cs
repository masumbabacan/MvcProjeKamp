using Business.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class AbilityController : Controller
    {
        // GET: Ability
        AbilityManager abilityManager = new AbilityManager(new EfAbilityDal());
        public ActionResult Index()
        {
            var abilityValues = abilityManager.GetAll();
            return View(abilityValues);
        }
    }
}