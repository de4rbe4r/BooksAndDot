using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BooksAndDot.Models;
using BooksAndDot.Models.Users;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using BooksAndDot.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BooksAndDot.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthenticationController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            var identity = GetIdentity(user);
            if (identity == null) return BadRequest(new { errorText = "Ошибка аутенфикации" });

            var now = DateTime.UtcNow;

            // Создаем JWT-токен
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDINCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                userName = identity.Name
            };
            return Ok(response);
        }

        private ClaimsIdentity GetIdentity(User user)
        {
            if (user == null) return null;

            User person = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            if (person == null) return null;
            var cryptedPassword = Convert.ToBase64String(
                System.Security.Cryptography.MD5.HashData(
                    Encoding.Unicode.GetBytes(user.Password)));
            if (person.Password != cryptedPassword) return null;
            person.Role = _context.Roles.FirstOrDefault(r => r.Id == person.RoleId);
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, person.FullName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role.Title)
            };
            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}
