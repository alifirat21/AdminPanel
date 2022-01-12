using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetCategoryList();
        void CategoryAdd(Category p);
        void CategoryDelete(Category p);
        void CategoryUpdate(Category p);
        Category GetByID(int id);
    }
}
