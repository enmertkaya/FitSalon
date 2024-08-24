using FitSalon.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSalon.DataAccessLayer.Abstract
{
    public interface ICommentDal : IGenericDal<Comment>
    {
        public List<Comment> GetListCommentWithService();

        public List<Comment> GetListCommentWithServiceAndUser(int id);

        public List<Comment> GetListCommentWithUser(int id);
    }
}
