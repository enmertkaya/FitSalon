﻿using FitSalon.BusinessLayer.Abstract;
using FitSalon.BusinessLayer.Abstract.AbstractUOW;
using FitSalon.DataAccessLayer.Abstract;
using FitSalon.DataAccessLayer.UnitOfWork;
using FitSalon.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSalon.BusinessLayer.Concrete.ConcreteUOW
{
    public class AccountManager : IAccountService
    {
        private readonly IAccountDal _accountDal;
        private readonly IUOWDal _uowDal;

        public AccountManager(IAccountDal accountDal, IUOWDal uowDal)
        {
            _accountDal = accountDal;
            _uowDal = uowDal;
        }

        public List<Account> TGetAccountWithEmployee()
        {
            return _accountDal.GetAccountWithEmployee();
        }

        public List<Account> TGetAll()
        {
            return _accountDal.GetAll();
        }

        public Account TGetByID(int id)
        {
            return _accountDal.GetByID(id);
        }

        public void TInsert(Account t)
        {
            _accountDal.Insert(t);
            _uowDal.Save();
        }

        public void TMultiUpdate(List<Account> t)
        {
            _accountDal.MultiUpdate(t);
            _uowDal.Save();
        }

        public void TUpdate(Account t)
        {
            _accountDal.Update(t);
            _uowDal.Save();
        }
    }
}
