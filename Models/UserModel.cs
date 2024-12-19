using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

public class UserModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string PasswordHash { get; set; } // Passwords are hashed

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<string> Roles { get; set; } = new List<string>(); // Roles: Admin, User, etc.
}
