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
    public class MessageController : Controller
    {
        // GET: Message
        //MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator validationRules = new MessageValidator();

        IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [Authorize]
        public ActionResult Inbox(string p)
        {
            var messageList = _messageService.GetAllInbox(p);
            return View(messageList);
        }

        public ActionResult Sendbox(string p)
        {
            var messageList = _messageService.GetAllSendbox(p);
            return View(messageList);
        }

        public ActionResult UnreadMessages(string p)
        {
            var messageList = _messageService.GetAllUnReadMessageList(p);
            return View(messageList);
        }

        public ActionResult DeletedMessageList(string p)
        {
            var messageList = _messageService.DeletedMessageList(p);
            return View(messageList);
        }


        public ActionResult GetInBoxMessageDetails(int id)
        {
            var values = _messageService.GetById(id);
            return View(values);
        }

        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var values = _messageService.GetById(id);
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
                _messageService.Add(message);
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

            var messageValue = _messageService.GetById(id);
            if (messageValue.MessageRead == true)
            {
                messageValue.MessageRead = false;
            }
            else
            {
                messageValue.MessageRead = true;
            }
            _messageService.Update(messageValue);
            return RedirectToAction("Inbox");
        }

        public ActionResult UnReadMessage(int id)
        {

            var messageValue = _messageService.GetById(id);
            if (messageValue.MessageRead == true)
            {
                messageValue.MessageRead = false;
            }
            else
            {
                messageValue.MessageRead = true;
            }
            _messageService.Update(messageValue);
            return RedirectToAction("UnreadMessages");
        }

        public ActionResult DeleteMessage(int id)
        {

            var messageValue = _messageService.GetById(id);
            if (messageValue.Status == true)
            {
                messageValue.Status = false;
            }
            else
            {
                messageValue.Status = true;
            }
            _messageService.Update(messageValue);
            return RedirectToAction("Inbox");
        }

        public ActionResult DeletedMessage(int id)
        {

            var messageValue = _messageService.GetById(id);
            if (messageValue.Status == true)
            {
                messageValue.Status = false;
            }
            else
            {
                messageValue.Status = true;
            }
            _messageService.Update(messageValue);
            return RedirectToAction("DeletedMessageList");
        }
    }
}