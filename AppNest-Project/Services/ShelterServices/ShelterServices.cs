using AppNest_Project.Data;
using AppNest_Project.DTOS.Shelter;
using AppNest_Project.DTOS.User;
using AppNest_Project.Models;
using AppNest_Project.Services.FileServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

namespace AppNest_Project.Services.ShelterServices
{
    public class ShelterServices : IShelterServices
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IFileServices _fileServices;
        public ShelterServices(ApplicationDbContext dataContext, IConfiguration configuration, IMapper mapper, IHttpContextAccessor contextAccessor, IFileServices fileServices)
        {
            _db = dataContext;
            _configuration = configuration;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _fileServices = fileServices;
        }
        private int GetUserId()
        {
            int userId = int.Parse(_contextAccessor.HttpContext.User.
                FindFirstValue(ClaimTypes.NameIdentifier));
            return userId;
        }
        public async Task<ServicesRespone<GetShelterDto>> CreateNewShelter(AddShelterDto shelter)
        {
           var respone= new ServicesRespone<GetShelterDto>();
            if (shelter == null)
            {
                respone.Success = false;
                return respone; 
            }
            var newShelter = _mapper.Map<Shelter>(shelter);
            newShelter.Owner = GetUserId();
            var resources = (Resources)Activator.CreateInstance(typeof(Resources));
            foreach (var property in typeof(Resources).GetProperties())
            {
                if (property.PropertyType == typeof(int))
                {
                    property.SetValue(resources, 0);
                }
            }
            newShelter.Resources = resources;
            _db.Shelters.Add(newShelter);
            await _db.SaveChangesAsync();
            var fileResult = _fileServices.SaveImage(shelter.ImageFile);
            if (shelter.ImageFile != null )
            {
                foreach (var image in fileResult)
                {
                    var newImage = new Images
                    {
                        ShelterId = newShelter.Id,
                   
                    };
                    if (image.Item1 == 1)
                    {
                        newImage.Image = image.Item2;
                    }

                    _db.Images.Add(newImage);
                }

                await _db.SaveChangesAsync();
            }


            respone.Data= _mapper.Map<GetShelterDto>(newShelter);
                
            return respone;
           
        }

        public Task<ServicesRespone<string>> DeleteShelter(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<ServicesRespone<List<GetShelterDto>>> GetAllShelters(FilterShelterDto filter)
        {
            var respone = new ServicesRespone<List<GetShelterDto>>();
            var shelters =  _db.Shelters.Include(e => e.Resources).Include(e=>e.Users).Include(e=>e.Images).ToList();
            PropertyInfo[] properties = filter.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                bool value = (bool)property.GetValue(filter);
                if (value != false)
                {

                    shelters = shelters.Where(s => s.Resources != null &&
                        ((property.Name == "Water" && s.Resources.Water>0 ) ||
                        (property.Name == "Clothes" && s.Resources.Clothes>0) ||
                        (property.Name == "Toy" && s.Resources.Toy >0) ||
                        (property.Name == "Medicine" && s.Resources.Medicine >0) ||
                        (property.Name == "Food" && s.Resources.Food > 0)))
                        .ToList();

                }
            }
            
            
            if (shelters == null)
            {
                respone.Success = false;
                return respone;
            }
           
            respone.Data = _mapper.Map<List<GetShelterDto>>(shelters);
            return respone; 
        }
       
        public async Task<ServicesRespone<GetShelterDto>> GetShelterDetails(int id)
        {
            var respone = new ServicesRespone<GetShelterDto>();
            Shelter data =await _db.Shelters.Include(e=>e.Users).Include(e=>e.Resources).Include(e=>e.Images).FirstOrDefaultAsync(s => s.Id == id);
            if (data == null)
            {
                respone.Success = false;
                respone.Message = "Shelter n't Found";
                return respone;
            }
           // data.Users = _mapper.Map<List<GetUserDto>>(data.Users);
            respone.Data = _mapper.Map<GetShelterDto>(data);
            return respone;

        }
    }
}
