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
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator validationRules = new MessageValidator();

        [Authorize]
        public ActionResult Inbox(string p)
        {
            var messageList = messageManager.GetAllInbox(p);
            return View(messageList);
        }

        public ActionResult Sendbox(string p)
        {
            var messageList = messageManager.GetAllSendbox(p);
            return View(messageList);
        }

        public ActionResult UnreadMessages(string p)
        {
            var messageList = messageManager.GetAllUnReadMessageList(p);
            return View(messageList);
        }

        public ActionResult DeletedMessageList(string p)
        {
            var messageList = messageManager.DeletedMessageList(p);
            return View(messageList);
        }


        public ActionResult GetInBoxMessageDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }

        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        { 
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult results = validationRules.Validate(message);
            if (results.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.Add(message);
                return RedirectToAction("SendBox");
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

        public ActionResult ReadMessage(int id)
        {

            var messageValue = messageManager.GetById(id);
            if (messageValue.MessageRead == true)
            {
                messageValue.MessageRead = false;
            }
            else
            {
                messageValue.MessageRead = true;
            }
            messageManager.Update(messageValue);
            return RedirectToAction("Inbox");
        }

        public ActionResult UnReadMessage(int id)
        {

            var messageValue = messageManager.GetById(id);
            if (messageValue.MessageRead == true)
            {
                messageValue.MessageRead = false;
            }
            else
            {
                messageValue.MessageRead = true;
            }
            messageManager.Update(messageValue);
            return RedirectToAction("UnreadMessages");
        }

        public ActionResult DeleteMessage(int id)
        {

            var messageValue = messageManager.GetById(id);
            if (messageValue.Status == true)
            {
                messageValue.Status = false;
            }
            else
            {
                messageValue.Status = true;
            }
            messageManager.Update(messageValue);
            return RedirectToAction("Inbox");
        }

        public ActionResult DeletedMessage(int id)
        {

            var messageValue = messageManager.GetById(id);
            if (messageValue.Status == true)
            {
                messageValue.Status = false;
            }
            else
            {
                messageValue.Status = true;
            }
            messageManager.Update(messageValue);
            return RedirectToAction("DeletedMessageList");
        }
    }
}