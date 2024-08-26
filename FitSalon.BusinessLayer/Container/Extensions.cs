using FitSalon.BusinessLayer.Abstract;
using FitSalon.BusinessLayer.Abstract.AbstractUOW;
using FitSalon.BusinessLayer.Concrete;
using FitSalon.BusinessLayer.Concrete.ConcreteUOW;
using FitSalon.BusinessLayer.ValidationRules.AnnouncementValidationRules;
using FitSalon.BusinessLayer.ValidationRules.AppUserValidationRules;
using FitSalon.BusinessLayer.ValidationRules.ContactUsValidationRules;
using FitSalon.BusinessLayer.ValidationRules.MemberValidationRules;
using FitSalon.DataAccessLayer.Abstract;
using FitSalon.DataAccessLayer.EntityFramework;
using FitSalon.DataAccessLayer.UnitOfWork;
using FitSalon.DtoLayer.DTOs.AnnouncementDTOs;
using FitSalon.DtoLayer.DTOs.AppUserDTOs;
using FitSalon.DtoLayer.DTOs.ContactDTOs;
using FitSalon.DtoLayer.DTOs.MemberDTOs;
using FitSalon.FDataAccessLayer.UnitOfWork;
using FitSalonDataAccessLayer.EntityFramework;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSalon.BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(IServiceCollection services)
        {
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EFCommentDal>();

            services.AddScoped<IServiceService, ServiceManager>();
            services.AddScoped<IServiceDal, EFServiceDal>();

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EFAppUserDal>();

            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IReservationDal, EFReservationDal>();

            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<IEmployeeDal, EFEmployeeDal>();

            services.AddScoped<IFeature1Service, Feature1Manager>();
            services.AddScoped<IFeature1Dal, EFFeature1Dal>();

            services.AddScoped<ISubAboutService, SubAboutManager>();
            services.AddScoped<ISubAboutDal, EFSubAboutDal>();

            services.AddScoped<ITestimonialService, TestimonialManager>();
            services.AddScoped<ITestimonialDal, EFTestimonialDal>();

            services.AddScoped<IContactUsService, ContactUsManager>();
            services.AddScoped<IContactUsDal, EFContactUsDal>();

            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EFContactDal>();

            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal, EFAnnouncementDal>();

            services.AddScoped<IAccountService, AccountManager>();
            services.AddScoped<IAccountDal, EFAccountDal>();

            services.AddScoped<IAbout1Service, About1Manager>();
            services.AddScoped<IAbout1Dal, EFAbout1Dal>();

            services.AddScoped<IUOWDal, UOWDal>();
        }

        public static void CustomValidator(IServiceCollection services)
        {
            services.AddTransient<IValidator<AnnouncementAddDTO>, AnnouncementValidator>();
            services.AddTransient<IValidator<SendMessageDTO>, SendContactUsValidator>();
            services.AddTransient<IValidator<AppUserLoginDTO>, AppUserSignInValidator>();
            services.AddTransient<IValidator<AppUserRegisterDTO>, AppUserRegisterValidator>();
            services.AddTransient<IValidator<UserEditDTO>, MemberProfileValidator>();
        }
    }
}
