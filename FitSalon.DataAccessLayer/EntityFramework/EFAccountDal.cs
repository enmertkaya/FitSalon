using FitSalon.DataAccessLayer.Abstract;
using FitSalon.DataAccessLayer.Concrete;
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
    public class EFAccountDal : GenericUOWRepository<Account>, IAccountDal
    {
        public EFAccountDal(Context context) : base(context)
        {
            
        }

        public List<Account> GetAccountWithEmployee()
        {
            using (var c = new Context())
            {
                return c.Accounts.Include(x => x.Employee).ToList();

            }
        }

       

       
    }
}
