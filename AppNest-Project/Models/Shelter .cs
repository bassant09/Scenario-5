using System.ComponentModel.DataAnnotations.Schema;

namespace AppNest_Project.Models
{
    public class Shelter
    {
        public int Id { get; set; }
        public int Owner { get; set; }
        public string Name { get; set; }
        public string? Location{ get; set; }
        public int MaxNum { get; set; }
        public State Availability { get; set; } = State.Available;
        public List<User>?Users  { get; set; }
        public List<Images>?Images{ get; set; }
        //  public  Resources { get; set; }

        [ForeignKey(nameof(Resources))]
        public int? ResourcesId { get; set; }
        public Resources? Resources { get; set; }
    } 
    public enum State
    {
        Available,
        Booked
    }
}
