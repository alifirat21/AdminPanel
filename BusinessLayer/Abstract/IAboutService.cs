using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        List<About> GetAboutList();
        void AboutAdd(About p);
        void AboutDelete(About p);
        void AboutUpdate(About p);
        About GetByID(int id);
    }
}
