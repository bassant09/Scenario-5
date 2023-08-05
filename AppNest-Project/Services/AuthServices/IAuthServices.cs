using AppNest_Project.DTOS.User;
using AppNest_Project.Models;

namespace AppNest_Project.Services.AuthServices
{
    public interface IAuthServices
    {
        Task<ServicesRespone<int>> Registeration(User user, string Password);
        Task<ServicesRespone<string>> Login(string Email, string Password);
        Task<bool> UserExist(String Username);
        Task<ServicesRespone<GetUserDto>> getUserInfo(int userId);

    }
}
