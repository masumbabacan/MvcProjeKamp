using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete;
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
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator validationRules = new MessageValidator();
        Context context = new Context();
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messageList = messageManager.GetAllInbox(p);
            return View(messageList);
        }

        public ActionResult SendboxWriter()
        {
            string p = (string)Session["WriterMail"];
            var messageList = messageManager.GetAllSendbox(p);
            return View(messageList);
        }

        public ActionResult UnreadMessages()
        {
            string p = (string)Session["WriterMail"];
            var messageList = messageManager.GetAllUnReadMessageList(p);
            return View(messageList);
        }

        public ActionResult DeletedMessageList()
        {
            string p = (string)Session["WriterMail"];
            var messageList = messageManager.DeletedMessageList(p);
            return View(messageList);
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

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            string sender = (string)Session["WriterMail"];
            ValidationResult results = validationRules.Validate(message);
            

            if (results.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                message.SenderMail = sender;
                messageManager.Add(message);
                return RedirectToAction("SendboxWriter");
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

















        public PartialViewResult MessageMenu()
        {

            //var incomingMessages = messageManager.GetAllInbox(p).Count();
            //ViewBag.incomingMessages = incomingMessages;

            //var sendMessage = messageManager.GetAllSendbox(p).Count();
            //ViewBag.sendMessage = sendMessage;

            //var unreadMessage = messageManager.GetAllUnReadMessageList().Count();
            //ViewBag.unreadMessage = unreadMessage;

            //var deletedMessage = messageManager.DeletedMessageList().Count();
            //ViewBag.deletedMessage = deletedMessage;
            return PartialView();
        }

    }
}