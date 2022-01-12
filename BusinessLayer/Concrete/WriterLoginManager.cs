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
    public class WriterLoginManager : IWriterLoginService
    {
        IWriterDal _writerDal;

        public WriterLoginManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetWriterLogin(string username, string password)
        {
            return _writerDal.GetID(x=>x.WriterMail == username && x.WriterPassword == password);
        }

        public void WriterAdd(Writer p)
        {
            _writerDal.Insert(p);
        }
    }
}
