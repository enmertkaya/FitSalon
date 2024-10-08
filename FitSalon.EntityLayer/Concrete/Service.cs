﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSalon.EntityLayer.Concrete
{
	public class Service
	{
		[Key]
		public int ServiceID { get; set; }
		public string CompanyName { get; set; }
		public string City { get; set; }
		public string DayNight { get; set; }
		public double Price { get; set; }
		public string Image { get; set; }
		public string Description { get; set; }
		public string? Capacity { get; set; }
        public string CoverImage { get; set; }
        public string Details1 { get; set; }
        public string Details2 { get; set; }
        public string Image2 { get; set; }
        public bool Status { get; set; }
		public List<Comment> Comments { get; set; }
        public List<Reservation> Reservations { get; set; }
		public int? EmployeeID { get; set; }
		public Employee Employee { get; set; }
    }
}
