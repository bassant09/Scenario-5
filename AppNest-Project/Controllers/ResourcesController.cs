using AppNest_Project.DTOS.AuthDto;
using AppNest_Project.DTOS.ResourcesDto;
using AppNest_Project.DTOS.Shelter;
using AppNest_Project.Models;
using AppNest_Project.Services.ResourcesShelter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace AppNest_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly IResourceServices _resourceService;
        public ResourcesController(IResourceServices resourceService)
        {
            _resourceService = resourceService;
        }
        [HttpPut("resources/{id}")]
        public async Task<ActionResult<ServicesRespone<GetShelterDto>>> UpdateShelterRescource(int id, [FromBody] AddResourceDto resorces)
        {
            var respone = await _resourceService.UpdateResources(id, resorces);
            if (!respone.Success)
            {
                return BadRequest(respone.Message);
            }
            return Ok(respone);

        }
    

        
    }
}
