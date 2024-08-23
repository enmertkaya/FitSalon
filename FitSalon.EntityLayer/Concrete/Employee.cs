using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSalon.EntityLayer.Concrete
{
	public class Employee
	{
		[Key]
		public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string InstagramURL { get; set; }
        public string FacebookURL { get; set; }
        public bool Status { get; set; }
        public List<Service> Services { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
