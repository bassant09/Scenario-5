using AppNest_Project.Models;

namespace AppNest_Project.DTOS.Shelter
{
    public class AddShelterDto
    {
        public string Name { get; set; }
        public string? Location { get; set; }
        //public List<Images>? Images { get; set; }
        public int MaxNum { get; set; }
        public List<IFormFile>? ImageFile { get; set; }

    }
}
