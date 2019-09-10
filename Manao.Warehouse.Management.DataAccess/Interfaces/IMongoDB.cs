using MongoDB.Driver;

namespace Manao.Warehouse.Management.DataAccess
{
    public interface IMongoDB
    {
        IMongoDatabase Database { get; }
        MongoClient Client { get; set; }
        void InitDatabase();
    }
}
