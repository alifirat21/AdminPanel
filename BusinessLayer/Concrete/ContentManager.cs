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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void AddContent(Content p)
        {
            _contentDal.Insert(p);
        }

        public void DeleteContent(Content p)
        {
            throw new NotImplementedException();
        }

        public Content GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetContentList()
        {
            return _contentDal.List();
        }

        public List<Content> GetContentListFİnd(string p)
        {
            return _contentDal.List(x=>x.ContentValue.Contains(p) || x.Heading.HeadingName.Contains(p));
        }

        public List<Content> GetListByHeadingID(int id)
        {
            return _contentDal.List(x=>x.HeadingID == id);
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentDal.List(x => x.WriterID == id);
        }

        public void UpdateContent(Content p)
        {
            throw new NotImplementedException();
        }
    }
}
