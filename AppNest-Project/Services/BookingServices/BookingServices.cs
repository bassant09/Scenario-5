using AppNest_Project.Data;
using AppNest_Project.DTOS.BookingDto;
using AppNest_Project.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AppNest_Project.Services.BookingServices
{
    public class BookingServices : IBookServices
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        public BookingServices(ApplicationDbContext dataContext, IConfiguration configuration, IMapper mapper, IHttpContextAccessor contextAccessor)
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

        public async Task<ServicesRespone<GetBookingDto>> AcceptShelterBooking(int id)
        {
            var respone = new ServicesRespone<GetBookingDto>();

            var data = await _db.Books.Include(e => e.User).FirstOrDefaultAsync(e => e.Id == id);
            if (data == null)
            {
                respone.Success = false;
                respone.Message = "Request not found.";
                return respone;
            }

            data.Status = BookingStatus.Booked;

            var shelter = await _db.Shelters.Include(s => s.Users).FirstOrDefaultAsync(s => s.Id == data.ShelterId);
            if (shelter == null)
            {
                respone.Success = false;
                respone.Message = "Shelter not found.";
                return respone;
            }

            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == data.UserId);
            if (user == null)
            {
                respone.Success = false;
                respone.Message = "User not found.";
                return respone;
            }

            if (shelter.Users == null)
            {
                shelter.Users = new List<User>();
            }

            shelter.Users.Add(user);
            _db.Shelters.Update(shelter);
            await _db.SaveChangesAsync();

            respone.Data = _mapper.Map<GetBookingDto>(data);
            return respone;
        }

        public async Task<ServicesRespone<GetBookingDto>> BookShelter(BookShelterDto book)
        {
            var respone = new ServicesRespone<GetBookingDto>();
            var shelter = await _db.Shelters.FirstOrDefaultAsync(e => e.Id == book.ShelterId);
            if (shelter == null)
            {
                respone.Success = false;
                respone.Message = "Shelter is N't Found";
                return respone; 
            }
            var Book = _mapper.Map<Booking>(book);
            Book.UserId = GetUserId();
            _db.Books.Add(Book);
           await _db.SaveChangesAsync();
            respone.Data=_mapper.Map<GetBookingDto>(Book);
            return respone;
        }

        public async Task<ServicesRespone<string>> CancelShelterBooking(int id)
        {
            var respone = new ServicesRespone<string>();
            var data = new Booking();
            data = await _db.Books.FirstOrDefaultAsync(e => e.Id==id);
            if (data == null)
            {
                respone.Success = false;
                respone.Message = "Shelter is N't Found";
                return respone;
            }
            _db.Books.Remove(data);
           await _db.SaveChangesAsync();
            respone.Data = "Canceled Successfully";
            return respone; 
        }

        public async Task<ServicesRespone<List<GetBookingDto>>> ShowBookingRequest()
        {
            var respone = new ServicesRespone<List<GetBookingDto>>();
            var requests = _db.Books.Include(e=>e.User).Include(e=>e.Shelter).Where(e => e.Status == BookingStatus.Pennding&&e.Shelter.Owner==GetUserId());
            respone.Data = _mapper.Map<List<GetBookingDto>>(requests);
            return respone;
           // throw new NotImplementedException();
        }
    }
}
