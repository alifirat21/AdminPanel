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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public Heading GetByID(int id)
        {
            return _headingDal.GetID(x => x.HeadingID == id);
        }

        public List<Heading> GetHeadingList()
        {
            return _headingDal.List();
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _headingDal.List(x => x.WriterID == id);
        }

        public void HeadingAdd(Heading p)
        {
            _headingDal.Insert(p);
        }

        public void HeadingDelete(Heading p)
        {
            _headingDal.Update(p);
        }

        public void HeadingUpdate(Heading p)
        {
            _headingDal.Update(p);
        }
    }
}
