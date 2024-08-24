using FitSalon.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSalon.DataAccessLayer.Abstract
{
	public interface ITestimonialDal : IGenericDal<Testimonial>
	{
        void ChangeToTrueByTestimonial(int id);
        void ChangeToFalseByTestimonial(int id);

    }
}
