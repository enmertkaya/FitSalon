using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSalon.EntityLayer.Concrete
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
        public int PersonCount { get; set; }
        public DateTime ReservationDate { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }   
        public int ServiceID { get; set; }

        public Service Service { get; set; }

    }
}
