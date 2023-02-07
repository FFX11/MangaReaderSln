
using DataLibrary.Models;

namespace MangaReader.Client.Services.UserService
{
    public interface IUserService
    {
        Task<MyUserModel> GetUser(MyUserModel id);
        Task DeleteManga(int id);
        Task<List<MyUserModel>> GetUsers();
        Task<MyUserModel> SaveManga(MyUserModel model);
        Task<MyUserModel> GetMainUser();
        Task<MyUserModel> GetCurrUser(int id);
        
    }
}