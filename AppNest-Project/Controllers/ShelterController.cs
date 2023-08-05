using AppNest_Project.DTOS.AuthDto;
using AppNest_Project.DTOS.Shelter;
using AppNest_Project.Models;
using AppNest_Project.Services.ShelterServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppNest_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShelterController : ControllerBase
    {
        private readonly IShelterServices _shelterServices;
        public ShelterController(IShelterServices shelterServices)
        {
            _shelterServices = shelterServices;

        }

        [HttpGet("shelters")]
        public async Task<ActionResult<ServicesRespone<List<GetShelterDto>>>> getAllShelters([FromQuery] FilterShelterDto filter)
        {
            var respone = await _shelterServices.GetAllShelters(filter);
            if (!respone.Success)
            {
                return BadRequest(respone.Message);
            }
            return Ok(respone);


        }
        [HttpPost]
        public async Task<ActionResult<ServicesRespone<List<GetShelterDto>>>> AddNewShelter([FromForm]  AddShelterDto shelter)
        {
            var respone = await _shelterServices.CreateNewShelter(shelter);
           if (!respone.Success)
            {
                return BadRequest(respone.Message);
            }
            return Ok(respone);

        }
        [HttpGet("details/{id}")]
        public async Task<ActionResult<ServicesRespone<GetShelterDto>>> GetShelterDetails(int id)
        {
            var respone = await _shelterServices.GetShelterDetails(id);
            if (!respone.Success)
            {
                return BadRequest(respone.Message);
            }
            return Ok(respone);


        }



    }
}
