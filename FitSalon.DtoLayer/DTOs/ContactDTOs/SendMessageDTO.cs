﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSalon.DtoLayer.DTOs.ContactDTOs
{
    public class SendMessageDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }
    }
}
