using MongoDB.Driver;

MongoClient client = new MongoClient("mongodb+srv://zykkhanbd:wEUPfPIoBwYDY4Cc@cluster0.fkpivbc.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");

List<string> databases = client.ListDatabaseNames().ToList();

foreach(string database in databases) {
    Console.WriteLine(database);
}

var playlistCollection = client.GetDatabase("sample_mflix").GetCollection<Playlist>("playlist");

// Insert Operation
List<string> movieList = new List<string>();
movieList.Add("Forrest Grump");

playlistCollection.InsertOne(new Playlist("zyk001", movieList));

// Reading the documents
// Find operation - create a filter that filters on the documents that you wish to find and returns back to the client

FilterDefinition<Playlist> filter = Builders<Playlist>.Filter.Eq("username", "zyk001");

List<Playlist> results = playlistCollection.Find(filter).ToList();
foreach(Playlist result in results){
    Console.WriteLine(string.Join(", ", result.items));
}

// Update the documents
// Filter to find the documents that we want to update
// Update definition for the criteria that we want to update within those found documents

// AddToSet: Adds the item to the list only if it doesn't already exist (avoiding duplicates)

UpdateDefinition<Playlist> update = Builders<Playlist>.Update.AddToSet<string>("items", "Titanic");

playlistCollection.UpdateOne(filter, update);

results = playlistCollection.Find(filter).ToList();
foreach(Playlist result in results){
    Console.WriteLine(string.Join(", ", result.items));
}

// delete operation
playlistCollection.DeleteOne(filter);
