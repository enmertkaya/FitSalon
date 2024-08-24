using FitSalon.DataAccessLayer.Abstract;
using FitSalon.DataAccessLayer.Concrete;
using FitSalon.DataAccessLayer.Repository;
using FitSalon.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSalon.DataAccessLayer.EntityFramework
{
    public class EFEmployeeDal : GenericRepository<Employee>, IEmployeeDal
    {
        Context context = new Context();

        public void ChangeToFalseByEmployee(int id)
        {
            var values = context.Employees.Find(id);
            values.Status = false;
            context.SaveChanges();
        }

        public void ChangeToTrueByEmployee(int id)
        {
            var values = context.Employees.Find(id);
            values.Status = true;
            context.SaveChanges();
        }

    }
}
