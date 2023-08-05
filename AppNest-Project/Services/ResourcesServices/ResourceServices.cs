using AppNest_Project.Data;
using AppNest_Project.DTOS.ResourcesDto;
using AppNest_Project.DTOS.Shelter;
using AppNest_Project.Models;
using AppNest_Project.Services.ResourcesShelter;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AppNest_Project.Services.ResourcesServices
{
    public class ResourceServices : IResourceServices
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        public ResourceServices(ApplicationDbContext dataContext, IConfiguration configuration, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _db = dataContext;
            _configuration = configuration;
            _mapper = mapper;
            _contextAccessor = contextAccessor;

        }
        private int GetUserId()
        {
            int userId = int.Parse(_contextAccessor.HttpContext.User.
                FindFirstValue(ClaimTypes.NameIdentifier));
            return userId;
        }
        public async Task<ServicesRespone<GetShelterDto>> UpdateResources(int id, AddResourceDto resources)
        {
            var respone = new ServicesRespone<GetShelterDto>(); 
            var shelter = await _db.Shelters.FirstOrDefaultAsync(e => e.Id == id);
            if (shelter == null)
            {
                respone.Success = false;
                respone.Message = "Shelter is n't found";
                return respone;
            }
            var shelterResources = shelter.Resources ?? new Resources();

            shelterResources.Food = resources.Food ?? 0;
            shelterResources.Water = resources.Water ?? 0;
            shelterResources.Clothes = resources.Clothes ?? 0;
            shelterResources.Medicine = resources.Medicine ?? 0;
            shelterResources.Toy = resources.Toy ?? 0;

            shelter.Resources = shelterResources;

            await _db.SaveChangesAsync();

            await _db.SaveChangesAsync();
            respone.Data = _mapper.Map<GetShelterDto>(shelter);
            return respone;
        }
    }
}
