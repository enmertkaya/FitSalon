using FitSalon.BusinessLayer.Abstract;
using FitSalon.BusinessLayer.Concrete;
using FitSalon.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FitSalon.WebUI.ViewComponents.Comment
{
    public class _CommentList : ViewComponent
    {
        CommentManager commentManager = new CommentManager (new EFCommentDal());
        public IViewComponentResult Invoke(int id)
        {
            var values = commentManager.TGetServiceByID(id);
            return View(values);
        }
    }
}
