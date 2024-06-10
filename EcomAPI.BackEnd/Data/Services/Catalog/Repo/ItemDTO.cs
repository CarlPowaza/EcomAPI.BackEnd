using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace EcomAPI.BackEnd.Data.Services.Catalog.Repo
{
    public class ItemDTO : IEntity
    {

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ItemGroupId { get; set; }
        public string Imgurl { get; set; }
        public string price { get; set; }
       
    }
}
