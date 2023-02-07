using Azure.Core;
using DataLibrary.Models;
using MangaReader.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;

namespace MangaReader.Server.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext, UserManager<ApplicationUser> userManager)
        {
            _appDbContext = appDbContext;
        }

        public async Task<MyUserModel> CreateUser(MyUserModel _user, string pass)
        {
            var result = await _appDbContext.UserModel.AddAsync(_user);
            await _appDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<MyUserModel> GetUser(string userId)
        {
            MyUserModel myUser = new();
            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == userId);

            if (user != null)
            {
                myUser.Email = user.Email;
                myUser.MangaClassId = user.UserModelId;
                myUser.Id = user.UserModelId;
            }

            return myUser;
        }

        public async Task DeleteManga(int id)
        {
            var user = await _appDbContext.UserModel.FirstOrDefaultAsync();
            var manga = await _appDbContext.Manga.FirstOrDefaultAsync(x => x.MangaClassId == id);

            if (manga != null)
            {
                _appDbContext.Remove(manga);
                _appDbContext.SaveChanges();
            }
        }

        public async Task<MyUserModel> GetUserByInt(int id)
        {
            MyUserModel myUser = new();
            var users = await _appDbContext.Users.ToListAsync();
            var manga = await _appDbContext.Manga.ToListAsync();
            var user =  _appDbContext.Users.Where(x => x.UserModelId == id).FirstOrDefault();

            if (user != null)
            {
                myUser.Id = user.UserModelId;
                myUser.PhotoPath = user.PhotoPath;
                myUser.Email = user.Email;
                myUser.MangaClassId = user.UserModelId;

                foreach (var m in manga.Where(x=> x.UserId == myUser.Id))
                {
                    myUser.Manga.Add(m);
                }
            }
            
            return myUser;
        }

        public async Task<List<MyUserModel>> GetUsers()
        {
            List<MyUserModel> myUsers = new();
            MyUserModel myUser = new();
            var users = await _appDbContext.Users.ToListAsync();

            foreach (var user in users)
            {
                myUser.Id= user.UserModelId;
                myUser.PhotoPath= user.PhotoPath;
                myUser.Email = user.Email;
                myUser.MangaClassId = user.UserModelId; 

                myUsers.Add(myUser);
                myUser= new();
            }
            return myUsers;
        }

        public async Task AddManga(MangaClass model)
        {

            await _appDbContext.AddAsync(model);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<MangaClass> GetManga(int id)
        {
            return await _appDbContext.Manga.FirstOrDefaultAsync(x => x.MangaClassId == id);
        }
    }
}

