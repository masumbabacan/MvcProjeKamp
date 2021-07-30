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
    public class ContactController : Controller
    {
        // GET: Contact
        //ContactManager contactManager = new ContactManager(new EfContactDal());
        //MessageManager messageManager = new MessageManager(new EfMessageDal());
        ContactValidator validationRules = new ContactValidator();

        IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public ActionResult Index()
        {
            var contactValues = _contactService.GetAll();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = _contactService.GetById(id);
            return View(contactValues);
        }

        [HttpGet]
        public ActionResult ContactAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactAdd(Contact contact)
        {
            contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _contactService.Add(contact);
            return RedirectToAction("HomePage", "Home");
        }



        public PartialViewResult MessageListMenu()
        {
            //var contact = contactManager.GetAll().Count();
            //ViewBag.contact = contact;

            //var incomingMessages = messageManager.GetAllInbox().Count();
            //ViewBag.incomingMessages = incomingMessages;

            //var sendMessage = messageManager.GetAllSendbox().Count();
            //ViewBag.sendMessage = sendMessage;

            //var unreadMessage = messageManager.GetAllUnReadMessageList().Count();
            //ViewBag.unreadMessage = unreadMessage;

            //var deletedMessage = messageManager.DeletedMessageList().Count();
            //ViewBag.deletedMessage = deletedMessage;

            return PartialView();
        }
    }
}