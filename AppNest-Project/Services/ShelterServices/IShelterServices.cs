using AppNest_Project.DTOS.Shelter;
using AppNest_Project.Models;

namespace AppNest_Project.Services.ShelterServices
{
    public interface IShelterServices
    {
        Task<ServicesRespone<List<GetShelterDto>>> GetAllShelters(FilterShelterDto filter);
        Task<ServicesRespone<GetShelterDto>> GetShelterDetails(int id);
        Task<ServicesRespone<GetShelterDto>> CreateNewShelter(AddShelterDto shelter);
        Task<ServicesRespone<string>> DeleteShelter(int id);
    }
}
