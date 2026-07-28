using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{
    // output dto
    public class UserDto
    {
        public required string DisplayName { get; set; } 

        public required string Id { get; set; }

        public required string Email { get; set; }

        public string? ImageUrl { get; set; }

        public required string Token { get; set; }
        
    }
}