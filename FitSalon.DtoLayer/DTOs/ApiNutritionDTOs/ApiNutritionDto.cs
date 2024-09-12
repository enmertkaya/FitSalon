using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSalon.DtoLayer.DTOs.ApiNutritionDTOs
{
    public class ApiNutritionDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public int caloric { get; set; }
        public string type { get; set; }
        public float fat { get; set; }
        public float carbon { get; set; }
        public float protein { get; set; }
        public int category_id { get; set; }
    }
}
