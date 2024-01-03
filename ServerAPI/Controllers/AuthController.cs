using AutoMapper;
using BusinessLogicLayer.Contracts;
using DataAccessLayer.DTO;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly string _connectionString;

        public AuthController(IAuthService authService, IConfiguration configuration, IMapper mapper)
        {
            _authService = authService;
            _configuration = configuration;
            _mapper = mapper;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private string GenerateJwtToken(string UserID)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims: new[] { new Claim(ClaimTypes.Name, UserID) },
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserDTO user)
        {
            try
            {
                bool isValidUser = _authService.ValidateUser(user.UserID, user.Password);

                if (isValidUser)
                {
                    var userDTO = _mapper.Map<UserDTO>(user);
                    var token = GenerateJwtToken(user.UserID);
                    return Ok(new { Message = "Login successful", Token = token });
                }
                else
                {
                    return Unauthorized(new { Message = "Invalid credentials" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An error occurred: {ex.Message}" });
            }
        }        

    }
}
