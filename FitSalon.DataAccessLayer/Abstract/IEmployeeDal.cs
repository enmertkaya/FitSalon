using FitSalon.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSalon.DataAccessLayer.Abstract
{
	public interface IEmployeeDal : IGenericDal<Employee>
	{
		void ChangeToTrueByEmployee(int id);
		void ChangeToFalseByEmployee(int id);

    }
}
