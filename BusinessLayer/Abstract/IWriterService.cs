using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetWriterList();
        Writer GetByID(int id);
        void WriterAdd(Writer p);
        void WriterDelete(Writer p);
        void WriterUpdate(Writer p);
    }
}
