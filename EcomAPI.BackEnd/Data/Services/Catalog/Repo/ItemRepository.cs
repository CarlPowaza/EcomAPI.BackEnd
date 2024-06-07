using EcomAPI.BackEnd.Data.Repo;
using MongoDB.Driver;

namespace EcomAPI.BackEnd.Data.Services.Catalog.Repo
{
    public class ItemRepository : MongoRepository<ItemDTO>
    {
        public ItemRepository(IMongoDatabase database)
            : base(database, "Item")
        {
        }

   
    }
}
