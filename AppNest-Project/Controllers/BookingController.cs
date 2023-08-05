using AppNest_Project.DTOS.BookingDto;
using AppNest_Project.DTOS.Shelter;
using AppNest_Project.Models;
using AppNest_Project.Services.BookingServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppNest_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookingController : ControllerBase
    {
        private readonly IBookServices _bookServices;
        public BookingController(IBookServices bookServices)
        {
            _bookServices = bookServices;

        }
        [HttpPost("BookShelter")]
        public async Task<ActionResult<ServicesRespone<GetShelterDto>>>BookShelter(BookShelterDto book)
        {
            var respone = await _bookServices.BookShelter(book);
            if (!respone.Success)
            {
                return BadRequest(respone.Message);
            }
            return Ok(respone);
        }
        [HttpGet("BookingRequest")]
        public async Task<ActionResult<ServicesRespone< List<GetShelterDto>>>> GetAllBookingRequest()
        {
            var respone = await _bookServices.ShowBookingRequest();
            if (!respone.Success)
            {
                return BadRequest(respone.Message);
            }
            return Ok(respone);
        }
        [HttpGet("AcceptShelterBooking/{id}")]
        public async Task<ActionResult<ServicesRespone<GetShelterDto>>> AcceptShelterBooking(int id)
        {
            var respone = await _bookServices.AcceptShelterBooking(id);
            if (!respone.Success)
            {
                return BadRequest(respone.Message);
            }
            return Ok(respone);
        }
        [HttpGet("CancelShelterBooking/{id}")]
        public async Task<ActionResult<ServicesRespone<string>>> CancelShelterBooking(int id)
        {
            var respone = await _bookServices.CancelShelterBooking(id);
            if (!respone.Success)
            {
                return BadRequest(respone.Message);
            }
            return Ok(respone);
        }

    }
}
