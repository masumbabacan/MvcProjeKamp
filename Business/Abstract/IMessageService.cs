using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMessageService
    {
        List<Message> GetAllInbox(string p);
        List<Message> GetAllUnReadMessageList(string p);
        List<Message> DeletedMessageList(string p);
        List<Message> GetAllSendbox(string p);

        Message GetById(int id);

        void Add(Message message);

        void Delete(Message message);

        void Update(Message message);
    }
}

