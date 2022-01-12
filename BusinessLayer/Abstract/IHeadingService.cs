using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetHeadingList();
        List<Heading> GetListByWriter(int id);
        void HeadingAdd(Heading p);
        void HeadingDelete(Heading p);
        void HeadingUpdate(Heading p);
        Heading GetByID(int id);
    }
}
