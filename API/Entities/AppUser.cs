// namespace is logical representation of where the class is located in the project structure. 
// not necessary to have the same name as the folder structure, but it is a good practice to do so.
namespace API.Entities
{
    public class AppUser
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        // public string Id { get; set; } = "";

        // public required string Id { get; set; }

        public required string DisplayName { get; set; }
        public required string Email { get; set; }

        public required byte[] PasswordHash { get; set; }   

        public required byte[] PasswordSalt { get; set; }
    }
}

// entity class is a class that represents a table in the database