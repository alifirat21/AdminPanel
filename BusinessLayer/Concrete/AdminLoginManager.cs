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
    public class AdminLoginManager : IAdminLoginService
    {
        IAdminDal _adminDal;

        public AdminLoginManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        public void AdminAdd(Admin p)
        {
            _adminDal.Insert(p);
        }
        public Admin GetAdminLogin(string username, string password)
        {
            return _adminDal.GetID(x => x.AdminUserName == username && x.AdminPassword == password);
        }
    }
}
