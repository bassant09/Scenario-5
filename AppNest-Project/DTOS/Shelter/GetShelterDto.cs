using AppNest_Project.Models;
using AppNest_Project.DTOS.User;
using AppNest_Project.DTOS.ResourcesDto;
using AppNest_Project.DTOS.Images_Dto;

namespace AppNest_Project.DTOS.Shelter
{
    public class GetShelterDto 
    {
        public int Id { get; set; }
        public int Owner { get; set; }
        public string Name { get; set; }
        public string? Location { get; set; }
        public int MaxNum { get; set; }
        public State Availability { get; set; }
        public List<GetImageDto>? Images { get; set; }
       public List<GetUserDto>?Users { get; set; }
        public Resources? Resources { get; set; }

    }
}
