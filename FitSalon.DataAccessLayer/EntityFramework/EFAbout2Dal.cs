﻿using FitSalon.DataAccessLayer.Abstract;
using FitSalon.DataAccessLayer.Repository;
using FitSalon.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSalon.DataAccessLayer.EntityFramework
{
	public class EFAbout2Dal : GenericRepository<About2>, IAbout2Dal
	{
	}
}
