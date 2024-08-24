using FitSalon.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSalon.BusinessLayer.ValidationRules
{
    public class AdminEmployeeValidator : AbstractValidator<Employee>
    {
        public AdminEmployeeValidator()
        {
            RuleFor(x => x.EmployeeName).NotEmpty().WithMessage("Lütfen rehberin adını soyadını giriniz!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Lütfen rehberin detay açıklamasını giriniz!");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Lütfen rehber görsel yolunu giriniz!");
        }
    }
}
