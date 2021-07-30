using Business.Abstract;
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
       // AbilityManager abilityManager = new AbilityManager(new EfAbilityDal());

        IAbilityService _abilityService;

        public AbilityController(IAbilityService abilityService)
        {
            _abilityService = abilityService;
        }

        public ActionResult Index()
        {
            var abilityValues = _abilityService.GetAll();
            return View(abilityValues);
        }
    }
}