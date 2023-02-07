using DataLibrary.Models.AccountModels;
using MangaReader.Server.Models;
using MangaReader.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;

namespace MangaReader.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserRepository _userRepository;

        public LoginController(IConfiguration configuration, SignInManager<ApplicationUser> signInManager, IUserRepository userRepository)
        {
            _configuration = configuration;
            _signInManager = signInManager;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Authorize]
        public UserInfo Get()
        {
            return new UserInfo()
            {
                Id = this.User.ToString(),
                Claims = this.User.Claims.ToDictionary(claim => claim.Type, claim => claim.Value)
            };
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, false);

            if (!result.Succeeded) return BadRequest(new LoginResult { Successful = false, Error = "Username and password are invalid." });

            var users = await _userRepository.GetUsers();
            var userId = users.Find(x => x.Email == login.Email).Id;

            var claims = new[]
            {

            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Name, login.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtAudience"],
                claims,
                expires: expiry,
                signingCredentials: creds
            );
            return Ok(new LoginResult { Successful = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
    public class UserInfo
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("claims")]
        public Dictionary<string, string> Claims { get; set; }
    }
}
