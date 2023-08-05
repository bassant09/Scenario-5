using AppNest_Project.DTOS.BookingDto;
using AppNest_Project.Models;

namespace AppNest_Project.Services.BookingServices
{
    public interface IBookServices
    {
        Task<ServicesRespone<List<GetBookingDto>>> ShowBookingRequest();
        Task<ServicesRespone<GetBookingDto>> BookShelter(BookShelterDto book);
        Task<ServicesRespone<GetBookingDto>> AcceptShelterBooking(int id);
        Task<ServicesRespone<string>> CancelShelterBooking(int id);
    }
}
