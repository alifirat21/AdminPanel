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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void ContactAdd(Contact p)
        {
            _contactDal.Insert(p);
        }

        public void ContactDelete(Contact p)
        {
            _contactDal.Delete(p);
        }

        public Contact GetByID(int id)
        {
            return _contactDal.GetID(x => x.ContactID == id);
        }

        public List<Contact> GetContactList()
        {
            return _contactDal.List();
        }

        public void ContactUpdate(Contact p)
        {
            _contactDal.Update(p);
        }
    }
}
