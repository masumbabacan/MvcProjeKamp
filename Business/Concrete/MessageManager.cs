using Business.Abstract;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message message)
        {
            _messageDal.Insert(message);
        }

        public void Delete(Message message)
        {
            _messageDal.Delete(message);
        }

        public List<Message> DeletedMessageList(string p)
        {
            return _messageDal.List(m => m.ReceiverMail == p && m.Status == false);
        }

        public List<Message> GetAllInbox(string p)
        {
            return _messageDal.List(m=>m.ReceiverMail== p && m.MessageRead == true && m.Status == true);
        }

        public List<Message> GetAllSendbox(string p)
        {
            return _messageDal.List(m => m.SenderMail ==p);
        }

        public List<Message> GetAllUnReadMessageList(string p)
        {
            return _messageDal.List(m => m.ReceiverMail == p && m.MessageRead == false);
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(m => m.MessageId == id);
        }

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
