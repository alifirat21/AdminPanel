using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetContentList();
        List<Content> GetContentListFİnd(string p);
        List<Content> GetListByWriter(int id);
        void AddContent(Content p);
        void DeleteContent(Content p);
        void UpdateContent(Content p);
        Content GetByID(int id);

        //Contente özel yazdık
        List<Content> GetListByHeadingID(int id);
    }
}
