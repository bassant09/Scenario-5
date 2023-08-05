using System.ComponentModel.DataAnnotations;

namespace AppNest_Project.DTOS.BookingDto
{
    public class BookShelterDto
    {
        public int ShelterId { get; set; }
       
        public string StartDay { get; set; }
       
        public string EndDay { get; set; }
    }
}
