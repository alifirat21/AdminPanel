﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void AboutAdd(About p)
        {
            _aboutDal.Insert(p);
        }

        public void AboutDelete(About p)
        {
            _aboutDal.Delete(p);
        }

        public void AboutUpdate(About p)
        {
            _aboutDal.Update(p);
        }

        public List<About> GetAboutList()
        {
            return _aboutDal.List();
        }

        public About GetByID(int id)
        {
            return _aboutDal.GetID(x => x.AboutID == id);
        }
    }
}
