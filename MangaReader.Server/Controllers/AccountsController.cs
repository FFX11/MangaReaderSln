using DataLibrary.Models.AccountModels;
using MangaReader.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MangaReader.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        //private static UserModel LoggedOutUser = new UserModel { IsAuthenticated = false };

        private readonly UserManager<ApplicationUser> _userManager;

        public AccountsController(UserManager<ApplicationUser> userManager = null)
        {
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult>Post([FromBody] RegisterModel model)
        {
            var newUser = new ApplicationUser { UserName = model.Email, Email = model.Email };

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);

                return Ok(new RegisterResult { Successful = false, Errors = errors });

            }

            return Ok(new RegisterResult { Successful = true });
        }
    }
}
