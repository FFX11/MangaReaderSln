using DataLibrary.Models;
using DataLibrary.Models.AccountModels;

namespace MangaReader.Client.Services.AuthenServices
{
    public interface IAuthService
    {
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();
        Task<RegisterResult> Register(RegisterModel registerModel);
    }
}