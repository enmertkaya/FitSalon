using FitSalon.DataAccessLayer.Abstract;
using FitSalon.DataAccessLayer.Repository;
using FitSalon.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSalonDataAccessLayer.EntityFramework
{
	public class EFFeature1Dal : GenericRepository<Feature1>, IFeature1Dal
	{
	}
}
