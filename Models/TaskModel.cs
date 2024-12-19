using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class TaskModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Priority { get; set; } // e.g., High, Medium, Low
    public DateTime Deadline { get; set; }
    public bool IsComplete { get; set; }
    public string UserId { get; set; } // Link to user identity
}
