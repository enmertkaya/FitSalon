using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSalon.EntityLayer.Concrete
{
    public class Account
    {
        public int AccountID { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
       public Employee Employee { get; set; }
       public int EmployeeID { get; set; }   
    }
}
