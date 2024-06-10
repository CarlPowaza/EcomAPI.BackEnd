using EcomAPI.BackEnd.Data.Interfaces.Repo;
using EcomAPI.BackEnd.Data.Repo;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace EcomAPI.BackEnd.Data.Services.Catalog.Repo
{
    public class ItemRepository : MongoRepository<ItemDTO>, IItemRepository
    {
        public ItemRepository(IMongoDatabase database)
            : base(database, "Item")
        {
        }

      

        // Implement any additional methods specific to Item repository if necessary
    }
}
