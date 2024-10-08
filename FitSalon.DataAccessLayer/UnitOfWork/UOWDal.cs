﻿using FitSalon.DataAccessLayer.Concrete;
using FitSalon.DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSalon.FDataAccessLayer.UnitOfWork
{
    public class UOWDal : IUOWDal
    {
        private readonly Context _context;

        public UOWDal(Context context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
