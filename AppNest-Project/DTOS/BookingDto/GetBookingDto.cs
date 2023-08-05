using AppNest_Project.DTOS.Shelter;
using AppNest_Project.DTOS.User;
using AppNest_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace AppNest_Project.DTOS.BookingDto
{
    public class GetBookingDto
    {
        public int Id { get; set; }
        public int ShelterId { get; set; }
        public GetUserDto User { get; set; }
        
        public string StartDay { get; set; }
       
        public string EndDay { get; set; }
        public BookingStatus Status { get; set; }
        public GetShelterDto Shelter { get; set; }

    }
}
