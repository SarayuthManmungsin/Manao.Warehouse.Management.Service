using Manao.Warehouse.Management.Domain;
using MongoDB.Bson.Serialization;
using System.Web.Http;

namespace Manao.Warehouse.Management.Service
{
    public class BsonConfig
    {
        public static void Register(HttpConfiguration config)
        {
            BsonClassMap.RegisterClassMap<Item>(cm => cm.AutoMap());
            BsonClassMap.RegisterClassMap<ItemHistory>(cm => cm.AutoMap());
            BsonClassMap.RegisterClassMap<ManaoUser>(cm => cm.AutoMap());
            BsonClassMap.RegisterClassMap<PurchaseOrder>(cm => cm.AutoMap());
        }
    }
}