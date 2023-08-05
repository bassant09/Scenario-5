using AppNest_Project.DTOS.ResourcesDto;
using AppNest_Project.DTOS.Shelter;
using AppNest_Project.Models;

namespace AppNest_Project.Services.ResourcesShelter
{
    public interface IResourceServices
    {
        Task<ServicesRespone<GetShelterDto>> UpdateResources(int id,AddResourceDto resources); 

    }
}
