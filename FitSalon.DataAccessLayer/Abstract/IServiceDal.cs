using FitSalon.DataAccessLayer.Migrations;
using FitSalon.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSalon.DataAccessLayer.Abstract
{
    public interface IServiceDal : IGenericDal<Service>
    {

        public Service GetServiceWithEmployee(int id);
        public List<Service> GetLast4Services();

    }
}
