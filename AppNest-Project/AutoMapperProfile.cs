using AppNest_Project.DTOS.BookingDto;
using AppNest_Project.DTOS.Images_Dto;
using AppNest_Project.DTOS.ResourcesDto;
using AppNest_Project.DTOS.Shelter;
using AppNest_Project.DTOS.User;
using AppNest_Project.Models;
using AutoMapper;

namespace AppNest_Project
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap< GetUserDto, User>().ReverseMap();
            CreateMap<GetShelterDto, Shelter>().ReverseMap();
            CreateMap<AddShelterDto, Shelter>().ReverseMap();
            CreateMap<AddResourceDto, Resources>().ReverseMap();
            CreateMap<BookShelterDto, Booking>().ReverseMap();
            CreateMap<GetBookingDto, Booking>().ReverseMap();
            CreateMap<GetResorcesDto, Resources>().ReverseMap();
            CreateMap<GetImageDto, Images>().ReverseMap();

        }
    }
}
