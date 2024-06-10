using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public interface IEntity
{

    int Id { get; set; }
}