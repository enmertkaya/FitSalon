using FitSalon.BusinessLayer.Abstract;
using FitSalon.DataAccessLayer.Abstract;
using FitSalon.DataAccessLayer.EntityFramework;
using FitSalon.DataAccessLayer.Migrations;
using FitSalon.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSalon.BusinessLayer.Concrete
{
    public class ServiceManager : IServiceService
    {
        IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public void TDelete(Service t)
        {
            _serviceDal.Delete(t);
        }

        public Service TGetByID(int id)
        {
            return _serviceDal.GetByID(id);
        }

        public Service TGetServiceWithEmployee(int id)
        {
            return _serviceDal.GetServiceWithEmployee(id);
        }
        public List<Service> TGetLast4Services()
        {
            return _serviceDal.GetLast4Services();
        }

        public List<Service> TGetList()
        {
            return _serviceDal.GetList();
        }

        public void TInsert(Service t)
        {
            _serviceDal.Insert(t);
        }

        public void TUpdate(Service t)
        {
            _serviceDal.Update(t);
        }
    }
}
