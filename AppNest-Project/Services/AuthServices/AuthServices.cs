using AppNest_Project.Data;
using AppNest_Project.DTOS.User;
using AppNest_Project.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AppNest_Project.Services.AuthServices
{
   
    public class AuthServices : IAuthServices
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        public AuthServices(ApplicationDbContext dataContext, IConfiguration configuration, IMapper mapper, IHttpContextAccessor contextAccessor)
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
        public async Task<ServicesRespone<string>> Login(string Email, string Password)
        {
            var respone = new ServicesRespone<string>();
            var user = await _db.Users.FirstOrDefaultAsync(e => e.Email == Email);
            if (user == null)
            {
                respone.Success = false;
                respone.Message = "User is n't Found";
            }
            else if (!VerifyPassword(Password, user.PasswordHash, user.PasswordSalt))
            {
                respone.Success = false;
                respone.Message = "Incorrect Password .";
            }
            else
            {
                respone.Success = true;
                respone.Data = CreateToken(user);
            }
            return respone;
        }

        public async Task<ServicesRespone<int>> Registeration(User user, string Password)
        {
            var respone = new ServicesRespone<int>();
            if (await UserExist(user.Email))
            {
                respone.Success = false;
                respone.Message = "User is already exists.";
                return respone;


            }
            CreatePasswordHash(Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            respone.Data = user.Id;
            return respone;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {

            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {

                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                 
        };
            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.
                GetBytes(_configuration.GetSection("AppSetting:Token").Value));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds

            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public Task<string> UpdateToken(string Token)
        {
            throw new NotImplementedException();
        }
    
    public async Task<bool> UserExist(string Email)
      {
            if (await _db.Users.AnyAsync(e => e.Email == Email))
            {
                return true;
            }
            return false;
        }

        public async Task<ServicesRespone<GetUserDto>> getUserInfo(int userId)
        {
            var respone= new ServicesRespone<GetUserDto>();
            var data = _db.Users.FirstOrDefaultAsync(e => e.Id == userId);
            if (data == null)
            {
                respone.Success = false;
                respone.Message = "User N't Found";

            }
            respone.Data = _mapper.Map<GetUserDto>(data);
            return respone; 
        }
    }
}
