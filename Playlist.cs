using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Playlist {
    public ObjectId _id { get; set; }
    [BsonElement("user")]
    public string username { get; set; } = null!; // nullable
    public List<string> items { get; set; } = null!; // nullable

    // constructor
    public Playlist(string username, List<string> movieIds) {
        this.username = username;
        this.items = movieIds;
    }

}