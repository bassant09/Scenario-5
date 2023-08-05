using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace AppNest_Project.Models
{
    public class Booking
    {
        public int Id{ get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey(nameof(Shelter))]
        public int ShelterId { get; set; }
        public Shelter Shelter { get; set; }

        
        public string StartDay { get; set; }
        
        public string EndDay { get; set; }
        public BookingStatus Status { get; set; } = BookingStatus.Pennding;

    }
    public enum BookingStatus
    {
        Pennding,
        Cancelled,
        Booked
    }
}
