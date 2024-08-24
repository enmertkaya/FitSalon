using FitSalon.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSalon.BusinessLayer.Abstract
{
	public interface IEmployeeService : IGenericService<Employee>
	{
        void TChangeToTrueByEmployee(int id);
        void TChangeToFalseByEmployee(int id);
    }
}
