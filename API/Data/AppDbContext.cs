using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{   
    // AppDbContext is derived from DbContext class, 
    // specified in EntityFrameWorkCore package. 
    // It is used to interact with the database.
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {   
        
        public DbSet<AppUser> Users { get; set; }
    }
}

/*
C# object               Database
-----------             ----------------
AppUser instance  <-->  one row

DbSet<AppUser>    <-->  Users table

AppDbContext      <-->  entire database

*/
