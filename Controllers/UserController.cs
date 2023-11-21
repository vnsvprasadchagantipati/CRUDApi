using AutoMapper;
using CRUDApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUDApi.Entities;
using CRUDApi.Dto;
using CRUDApi.Services;
using CRUDApi.Database;
using CRUDApi.Repository;
using CRUDApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CRUDApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService userService;
        private readonly IConfiguration configuration;

        public UserController(IMapper mapper, IUserService userService, IConfiguration configuration)
        {
            _mapper = mapper;
            this.userService = userService;
            this.configuration = configuration;
        }

        [HttpPost]


        public IActionResult Add([FromBody] UserDto userDto) 
        {
            try
            {
                User user = _mapper.Map<User>(userDto);
                userService.add(user);
                return StatusCode(200, user);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        [Authorize(Roles = "User")]
        public IActionResult Put(UserDto userDto) 
        
        {
            try
            {
                User user = _mapper.Map<User>(userDto);
                userService.update(user);
                return StatusCode(200, user);
            }
            catch (Exception)
            {

                throw;
            }
        
        }
        [HttpPost, Route("Validate")]
        [AllowAnonymous]
        public IActionResult Validate(Login login)
        {
            try
            {
                User user = userService.ValidteUser(login.Email, login.Password);
                AuthReponse authReponse = new AuthReponse();
                if (user != null)
                {
                    authReponse.UserName = user.UserName;
                    authReponse.Role = user.Role;
                    authReponse.Token = GetToken(user);
                }
                return StatusCode(200, authReponse);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        private string GetToken(User? user)
        {
            var issuer = configuration["Jwt:Issuer"];
            var audience = configuration["Jwt:Audience"];
            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
            //header part
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature
            );
            //payload part
            var subject = new ClaimsIdentity(new[]
            {
                        new Claim(ClaimTypes.Name,user.UserName),
                        new Claim(ClaimTypes.Role, user.Role),
                        new Claim(ClaimTypes.Email,user.UserEmail),
                    });

            var expires = DateTime.UtcNow.AddMinutes(10);
            //signature part
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = expires,
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            return jwtToken;
        }
    }
}
