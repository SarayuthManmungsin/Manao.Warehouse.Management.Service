using MongoDB.Driver;
using System.Configuration;

namespace Manao.Warehouse.Management.DataAccess
{
    public class MongoDB : IMongoDB
    {
        private static IMongoDatabase _database;

        public void InitDatabase()
        {
            if (Client != null)
            {
                var database = ConfigurationManager.AppSettings["DatabaseName"];
                _database = Client.GetDatabase(database);
            }
        }

        public IMongoDatabase Database
        {
            get
            {
                return _database;
            }
        }

        public MongoClient Client { get; set; }
    }
}
