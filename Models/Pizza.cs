using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ContosoPizza.Models;


public class Pizza
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? Name { get; set; }
    public bool IsGlutenFree { get; set; }
}