using FitSalon.BusinessLayer.Abstract;
using FitSalon.DataAccessLayer.Abstract;
using FitSalon.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSalon.BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
       ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void TDelete(Comment t)
        {
            _commentDal.Delete(t); 
        }

        public Comment TGetByID(int id)
        {
           return _commentDal.GetByID(id);
        }

        public List<Comment> TGetList()
        {
            return _commentDal.GetList();
        }

        public void TInsert(Comment t)
        {
            _commentDal.Insert(t);
        }

        public void TUpdate(Comment t)
        {
            _commentDal.Update(t);
        }

        public List<Comment> TGetListCommentWithUser(int id)
        {
            return _commentDal.GetListCommentWithUser(id);
        }

        public List<Comment> TGetServiceByID(int id)
        {
            return _commentDal.GetListByFilter(x => x.ServiceID == id);
        }

        public List<Comment> TGetListCommentWithService()
        {
            return _commentDal.GetListCommentWithService();
        }

        public List<Comment> TGetListCommentWithServiceAndUser(int id)
        {
            return _commentDal.GetListCommentWithServiceAndUser(id);

        }
    }
}
