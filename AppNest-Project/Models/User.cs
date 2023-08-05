namespace AppNest_Project.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Email{ get; set; }
        public int Age { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PersonalImage { get; set; }
        public string? Location { get; set; }
        public int? ShelterId { get; set; }
        public Shelter? Shelter { get; set; }
    }
}
