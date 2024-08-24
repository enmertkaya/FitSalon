using FitSalon.DataAccessLayer.Abstract;
using FitSalon.DataAccessLayer.Concrete;
using FitSalon.DataAccessLayer.Repository;
using FitSalon.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSalon.DataAccessLayer.EntityFramework
{
    public class EFCommentDal : GenericRepository<Comment>, ICommentDal
    {
        

        public List<Comment> GetListCommentWithService()
        {
            using (var c = new Context())
            {
                return c.Comments.Include(x => x.Service).Include(x => x.AppUser).ToList();
            }
        }

        public List<Comment> GetListCommentWithServiceAndUser(int id)
        {
            using (var c = new Context())
            {
                return c.Comments.Where(x => x.ServiceID == id).Include(x => x.AppUser).ToList();
            }
        }

        public List<Comment> GetListCommentWithUser(int id)
        {
            using (var c = new Context())
            {
                return c.Comments.Include(x => x.AppUser).ToList();
            }
        }
    }
}
