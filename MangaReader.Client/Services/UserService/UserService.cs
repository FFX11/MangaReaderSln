using DataLibrary.Models;
using System.Net.Http.Json;

namespace MangaReader.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MyUserModel> GetUser(MyUserModel id)
        {
            var response = await _httpClient.PostAsJsonAsync<MyUserModel>($"api/user/getuser",id);
            var result  = response.Content.ReadFromJsonAsync<MyUserModel>();

            return result.Result;
        }

        public async Task DeleteManga(int id)
        {
            await _httpClient.DeleteAsync($"api/User/delete/{id}");
        }

        public async Task<MyUserModel> GetMainUser()
        {
            return await _httpClient.GetFromJsonAsync<MyUserModel>("api/User/mainuser/");
        }

        public async Task<List<MyUserModel>> GetUsers()
        {
            return await _httpClient.GetFromJsonAsync< List<MyUserModel>>("api/User/users/");
        }

        public async Task<MyUserModel> SaveManga(MyUserModel model)
        {
            var result = await _httpClient.PutAsJsonAsync<MyUserModel>("api/User/savemanga/", model);

            if (result.IsSuccessStatusCode == false)
            {
                throw new Exception(result.ReasonPhrase);
            }
            return model;
        }

        public async Task<MyUserModel> GetCurrUser(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<MyUserModel>($"api/User/getmainuser/{id}");

           
            if (result == null)
            {
                throw new Exception();
            }
            return result;
        }

        //public async Task<MyUserModel> AddManga(MyUserModel model)
        //{
        //    var result = await _httpClient.PostAsJsonAsync<MyUserModel>("api/User/AddManga/", model);
        //    if (result.IsSuccessStatusCode == false)
        //    {
        //        throw new Exception(result.ReasonPhrase);
        //    }
        //    return model;
        //}
    }
}
