using FitSalon.DataAccessLayer.Abstract;
using FitSalon.DataAccessLayer.Concrete;
using FitSalon.DataAccessLayer.Migrations;
using FitSalon.DataAccessLayer.Repository;
using FitSalon.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSalon.DataAccessLayer.EntityFramework
{
    public class EFServiceDal : GenericRepository<Service>, IServiceDal
    {
        public Service GetServiceWithEmployee(int id)
        {
            using (var c = new Context())
            {
                return c.Services.Where(x => x.ServiceID == id).Include(x => x.Employee).FirstOrDefault();
            }
        }
        public List<Service> GetLast4Services()
        {
            using (var context = new Context())
            {
                var values = context.Services.Take(4).OrderByDescending(x => x.ServiceID).ToList();
                return values;
            }
        }
    }
}
