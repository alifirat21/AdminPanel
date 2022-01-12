using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetByID(int id)
        {
            return _messageDal.GetID(x => x.MessageID == id);
        }


        public List<Message> GetListInbox(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p);
        }

      

        public List<Message> GetListSendbox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p);
        }

        public void MessageAdd(Message p)
        {
            _messageDal.Insert(p);
        }

        public void MessageDelete(Message p)
        {
            _messageDal.Delete(p);
        }

        public void MessageUpdate(Message p)
        {
            _messageDal.Update(p);
        }
    }
}
