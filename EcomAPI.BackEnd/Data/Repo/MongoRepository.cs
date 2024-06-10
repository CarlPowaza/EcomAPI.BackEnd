namespace EcomAPI.BackEnd.Data.Repo
{
    using MongoDB.Driver;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System.Linq.Expressions;

    public class MongoRepository<T> : IRepository<T> where T : IEntity
    {
        private readonly IMongoCollection<T> _collection;

        public MongoRepository(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task<List<T>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<T?> GetByIdAsync(int id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(T entity) =>
            await _collection.InsertOneAsync(entity);

        public async Task UpdateAsync(int id, T entity) =>
            await _collection.ReplaceOneAsync(x => x.Id == id, entity);

        public async Task DeleteAsync(int id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);

        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> filter) =>
            await _collection.Find(filter).ToListAsync();


    }
}
