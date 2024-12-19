using MongoDB.Driver;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration["MongoDB:ConnectionString"]);
        _database = client.GetDatabase(configuration["MongoDB:DatabaseName"]);
    }

    public IMongoCollection<TaskModel> Tasks => _database.GetCollection<TaskModel>("Tasks");
    public IMongoCollection<UserModel> Users => _database.GetCollection<UserModel>("Users");
}
