using FitSalon.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSalon.BusinessLayer.Abstract
{
	public interface ITestimonialService : IGenericService<Testimonial>
	{
        void TChangeToTrueByTestimonial(int id);
        void TChangeToFalseByTestimonial(int id);
    }
}
