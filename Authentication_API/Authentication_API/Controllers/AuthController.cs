using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Authentication_API.Exceptions;
using Authentication_API.Models;
using Authentication_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Authentication_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region ReadOnly Field
        private readonly IAuthService authService;
        #endregion

        #region Constructor
        public AuthController(IAuthService auth)
        {
            authService = auth;
        }
        #endregion

        #region Crud Operations
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] User user)
        {
            try
            {
                return Created("", authService.RegisterUser(user));
            }
            catch (UserAlreadyExistsException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong");
            }
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] User user)
        {
            try
            {
                bool _user = authService.LoginUser(user);
                if (_user == true)
                    return Ok(GetToken(user.UserId));

                return Unauthorized("Invalid user id or password");
            }

            catch (Exception)
            {
                return StatusCode(500, "Something wrong");
            }
        }
        #endregion

        #region Generating Token
        private string GetToken(string userId)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName,userId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secret_auth_jwt_to_secure_microservice"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "AuthenticationServer",
                audience: "AuthClient",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(25),
                signingCredentials: creds
            );
            var response = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            };
            return JsonConvert.SerializeObject(response);
        }
        #endregion


    }
}
