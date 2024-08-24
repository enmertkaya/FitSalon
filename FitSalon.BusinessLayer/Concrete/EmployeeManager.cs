using FitSalon.BusinessLayer.Abstract;
using FitSalon.DataAccessLayer.Abstract;
using FitSalon.DataAccessLayer.EntityFramework;
using FitSalon.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSalon.BusinessLayer.Concrete
{
	public class EmployeeManager : IEmployeeService
	{
		IEmployeeDal _employeeDal;

		public EmployeeManager(IEmployeeDal employeeDal)
		{
			_employeeDal = employeeDal;
		}

        public void TChangeToFalseByEmployee(int id)
        {
			_employeeDal.ChangeToFalseByEmployee(id);
        }

        public void TChangeToTrueByEmployee(int id)
        {
			_employeeDal.ChangeToTrueByEmployee(id);
        }

        public void TDelete(Employee t)
		{
			_employeeDal.Delete(t);
		}

		public Employee TGetByID(int id)
		{
			return _employeeDal.GetByID(id);
        }

		public List<Employee> TGetList()
		{
			return _employeeDal.GetList();

		}

		public void TInsert(Employee t)
		{
            _employeeDal.Insert(t);
		}

		public void TUpdate(Employee t)
		{
            _employeeDal.Update(t);	
		}
	}
}
