using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    // this api achieves two functions, user registration and login
    public class AccountController(AppDbContext context, ITokenService tokenService) : BaseApiController
    {

        [HttpPost("register")] //localhost:5000/api/account/register
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            //email dup check 
            if (await EmailExists(registerDto.Email)) return BadRequest("Email already exists");
            
            using var hmac = new HMACSHA512();
            
            //covert registerDto to AppUser entity
            var user = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key              
            };

            // save new AppUser to db
            context.Users.Add(user);
            await context.SaveChangesAsync();

            //return UserDto to client, which contains jwt token
            return user.ToDto(tokenService);
        }


        [HttpPost("login")] //localhost:5000/api/account/login
        // use email and password to login
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await context.Users.SingleOrDefaultAsync(x => x.Email == loginDto.Email);

            if(user == null) return Unauthorized("User not found with this email address");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            return user.ToDto(tokenService);
        }


        private async Task<bool> EmailExists(string email)
        {
            return await context.Users.AnyAsync(x => x.Email == email.ToLower());
        }
    }
}