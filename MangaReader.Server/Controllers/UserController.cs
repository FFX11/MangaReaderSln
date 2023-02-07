using DataLibrary.Models;
using MangaReader.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Numerics;
using System.Security.Claims;

namespace MangaReader.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {
                var manga = await _userRepository.GetManga(id);

                if (manga == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                 await _userRepository.DeleteManga(manga.MangaClassId);
                return RedirectToAction("userpage");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        [HttpPut("savemanga")]
        public async Task<ActionResult<MyUserModel>> AddMangaToUser(MyUserModel model)
        {
            var user = await _userRepository.GetUserByInt(model.Id);

            try
            {
                if (user != null)
                {
                    

                    await _userRepository.AddManga(model.Manga.FirstOrDefault());
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
            return Ok(ModelState);
        }

        [HttpGet("users")]
        public async Task<ActionResult<List<MyUserModel>>> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            if (users == null)
                return NotFound();
            return Ok(users);
        }

        [HttpPut("mainuser")]
        public async Task<ActionResult<MyUserModel>> GetUser(MyUserModel model)
        {
            var user = await _userRepository.GetUser(model.Email);
            var manga = await _userRepository.GetManga(user.Id);

            user.Manga.Add(manga);

            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpGet("getmainuser/{id}")]
        public async Task<ActionResult<MyUserModel>> GetEmployee(int id)
        {
            var user = await _userRepository.GetUserByInt(id);
            try
            {
                
                if (user == null) return NotFound();

                return user;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
