namespace EcomAPI.BackEnd.Data.Repo
{
    using MongoDB.Driver;
    using Microsoft.Extensions.Options;

    public class MongoDBService
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            _client = new MongoClient(mongoDBSettings.Value.ConnectionString);
            _database = _client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        }

        public IMongoDatabase GetDatabase() => _database;
    }
}
