using MongoDB.Driver;
using System.Configuration;

namespace Manao.Warehouse.Management.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private static IMongoDB _mongoDB;

        public IMongoDatabase Database
        {
            get
            {
                return _mongoDB.Database;
            }
        }

        public UnitOfWork()
        {
            OpenSession();
        }

        public void Commit()
        {

        }

        public void Dispose()
        {
            _mongoDB = null;
        }

        private void OpenSession()
        {
            if (_mongoDB == null)
                _mongoDB = new MongoDB();

            if (_mongoDB.Client == null)
            {
                var host = ConfigurationManager.AppSettings["DatabaseHost"];
                var port = ConfigurationManager.AppSettings["DatabasePort"];

                MongoClientSettings setting = new MongoClientSettings();
                setting.Server = new MongoServerAddress(host, int.Parse(port));
                _mongoDB.Client = new MongoClient(setting);

                _mongoDB.InitDatabase();
            }
        }
    }
}
