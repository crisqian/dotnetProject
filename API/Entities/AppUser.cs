// namespace is logical representation of where the class is located in the project structure. 
// not necessary to have the same name as the folder structure, but it is a good practice to do so.
namespace API.Entities
{
    public class AppUser
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        // public string Id { get; set; } = "";

        // public required string Id { get; set; }

        public string? DisplayName { get; set; }
        public string? Email { get; set; }
    }
}

// entity class is a class that represents a table in the database