using FitSalon.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSalon.BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        List<Comment> TGetServiceByID(int id);
        List<Comment> TGetListCommentWithService();
        List<Comment> TGetListCommentWithServiceAndUser(int id);
        List<Comment> TGetListCommentWithUser(int id);
    }
}
