using DataLibrary.Models;
using DataLibrary.Models.UserModels;

namespace MangaReader.Server.Services
{
    public interface IUserRepository
    {
        Task<List<MyUserModel>> GetUsers();
        Task<MangaClass> GetManga(int id);
        Task<MyUserModel> GetUser(string userId);
        Task AddManga(MangaClass model);
        Task<MyUserModel> GetUserByInt(int id);
        Task DeleteManga(int id);
        Task<MyUserModel> CreateUser(MyUserModel employee, string pass);
    }
}