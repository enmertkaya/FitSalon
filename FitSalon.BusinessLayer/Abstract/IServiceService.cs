using FitSalon.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSalon.BusinessLayer.Abstract
{
	public interface IServiceService : IGenericService<Service>
	{

        public Service TGetServiceWithEmployee(int id);
    }
}
