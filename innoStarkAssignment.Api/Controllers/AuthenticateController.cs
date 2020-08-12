using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using AutoMapper.Configuration;
using innoStarkAssignment.Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;

namespace innoStarkAssignment.Api.Controllers
{
    public class AuthenticateController : BaseController
    {
        #region Property  
        /// <summary>  
        /// Property Declaration  
        /// </summary>  
        /// <param name="data"></param>  
        /// <returns></returns>  
        private readonly IConfiguration _config;

        #endregion

        #region Contructor Injector  
        /// <summary>  
        /// Constructor Injection to access all methods or simply DI(Dependency Injection)  
        /// </summary>  
        public AuthenticateController(IConfiguration configiguration)
        {
            _config = configiguration;
        }
        #endregion

        #region GenerateJWT  
        /// <summary>  
        /// Generate Json Web Token Method  
        /// </summary>  
        /// <param name="userInfo"></param>  
        /// <returns></returns>  
        private string GenerateJSONWebToken(Login userInfo)
        {
            
              var key = _config.GetValue<string>("Jwt:Key");
            var issuer = _config.GetValue<string>("Jwt:Issuer");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer,
              issuer,
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion

        #region AuthenticateUser  
        /// <summary>  
        /// Hardcoded the User authentication  
        /// </summary>  
        /// <param name="login"></param>  
        /// <returns></returns>  
        private async Task<Login> AuthenticateUser(Login login)
        {
            Login user = null;

            //Validate the User Credentials      
            //Demo Purpose, I have Passed HardCoded User Information      
            if (login.UserName == "innostark")
            {
                user = new Login { UserName = "innostark", Password = "123456" };
            }
            return user;
        }
        #endregion

        #region Login Validation  
        /// <summary>  
        /// Login Authenticaton using JWT Token Authentication  
        /// </summary>  
        /// <param name="data"></param>  
        /// <returns></returns>  
        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login([FromBody] Login data)
        {
            IActionResult response = Unauthorized();
            var user = await AuthenticateUser(data);
            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { Token = tokenString, Message = "Success" });
            }
            return response;
        }
        #endregion

        

    }
}