using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{   // container of client request 
    public class RegisterDto
    {

        //? tells compiler this property is nullable 
        // but [Required] tells ASP.NET, after model binding(fill in RegisterDto with json value from client), this property cannot be null, otherwise return 400 bad request
        // this cannot be null
        [Required]
        public required string DisplayName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";
        
        [Required]
        [MinLength(4)]
        public required string Password { get; set; }


       //required 是 C# 语言特性，主要约束 C# 代码创建对象
    }
}