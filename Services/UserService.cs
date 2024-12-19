using MongoDB.Driver;
using Microsoft.AspNetCore.Identity;

public class UserService
{
    private readonly IMongoCollection<UserModel> _users;
    private readonly IPasswordHasher<UserModel> _passwordHasher;

    public UserService(MongoDbContext context, IPasswordHasher<UserModel> passwordHasher)
    {
        _users = context.Users;
        _passwordHasher = passwordHasher;
    }

    // Register a new user
    public async Task<bool> RegisterUserAsync(UserModel user, string password)
    {
        if (await _users.Find(u => u.Email == user.Email).AnyAsync())
        {
            return false; // Email already exists
        }

        user.PasswordHash = _passwordHasher.HashPassword(user, password);
        await _users.InsertOneAsync(user);
        return true;
    }

    // Authenticate user during login
    public async Task<UserModel> AuthenticateAsync(string email, string password)
    {
        var user = await _users.Find(u => u.Email == email).FirstOrDefaultAsync();
        if (user != null)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if (result == PasswordVerificationResult.Success)
            {
                return user;
            }
        }
        return null;
    }
}
