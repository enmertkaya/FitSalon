﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSalon.DtoLayer.DTOs.AnnouncementDTOs
{
    public class AnnouncementEditDTO
    {
        public int AnnouncementID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }  
    }
}
