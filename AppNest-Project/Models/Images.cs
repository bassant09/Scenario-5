namespace AppNest_Project.Models
{
    public class Images
    {
        public int Id { get; set; }
        public int ShelterId { get; set; }
        public Shelter Shelter { get; set; }
        public string Image { get; set; }
    }
}
