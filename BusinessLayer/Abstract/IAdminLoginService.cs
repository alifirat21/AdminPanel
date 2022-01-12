﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminLoginService
    {
        Admin GetAdminLogin(string username, string password);

        void AdminAdd(Admin p);

    }
}
