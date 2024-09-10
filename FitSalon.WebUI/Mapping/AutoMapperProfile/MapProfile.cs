using AutoMapper;
using FitSalon.DtoLayer.DTOs.AdminDTOs;
using FitSalon.DtoLayer.DTOs.AnnouncementDTOs;
using FitSalon.DtoLayer.DTOs.AppUserDTOs;
using FitSalon.DtoLayer.DTOs.ContactDTOs;
using FitSalon.EntityLayer.Concrete;

namespace FitSalon.WebUI.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {   
                CreateMap<AppUserRegisterDTO, AppUser>().ReverseMap();

                CreateMap<AppUserLoginDTO, AppUser>().ReverseMap();

                CreateMap<EditUserDTO, AppUser>().ReverseMap();

                CreateMap<AnnouncementListDTO, Announcement>().ReverseMap();

                CreateMap<AnnouncementAddDTO, Announcement>().ReverseMap();

                CreateMap<AnnouncementEditDTO, Announcement>().ReverseMap();

                CreateMap<SendMessageDTO, ContactUs>().ReverseMap();
        }
    }
}
