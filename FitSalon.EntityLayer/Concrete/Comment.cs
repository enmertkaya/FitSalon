using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSalon.EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string? CommentUser { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentContent { get; set; }
        public bool CommentStatus { get; set; }
        public int ServiceID { get; set; }  
        public Service Service { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }

    }
}
