using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Principal;
using Case_Marking_Web_Application.Interfaces;
using DataAccessLayer.Models;

namespace Case_Marking_Web_Application.Service
{
    public class AuthenticationService: ControllerBase, IAuthenticationService
    {
        private readonly CaseMarkingDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public AuthenticationService(IConfiguration configuration, CaseMarkingDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Login(LoginModel model)
        {
            var userObj = _dbContext.Users
                              .Where(i => i.Email == model.UserName && i.Password == model.Password)
                              .Select(identity => new
                              {
                                  IdentityId = identity.UserId,
                                  Email = identity.Email,
                                  RoleId = identity.Role,
                              })
                              .FirstOrDefault();

            if (userObj != null)
            {

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, userObj.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role, userObj.RoleId.ToString())
                };

                var token = GetToken(authClaims);


                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    userData = userObj
                });

            }
            else
                return Unauthorized();

        }


        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3600),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256Signature)
                );

            return token;
        }
    }
}
