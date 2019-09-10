using Manao.Warehouse.Management.DataAccess;
using Manao.Warehouse.Management.Domain;
using Manao.Warehouse.Management.Utils;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manao.Warehouse.Management.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, IDomainBase
    {
        private readonly IUnitOfWork _unitOfWork = ObjectFactory.GetInstance<IUnitOfWork>();
        protected readonly IMongoCollection<T> _collection;

        public RepositoryBase()
        {
            _collection = _unitOfWork.Database.GetCollection<T>(typeof(T).Name.Substring(1));
        }

        public async Task<T> Get(ObjectId id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            return await _collection.Find<T>(filter).FirstOrDefaultAsync();
        }

        public async Task<IList<T>> Get()
        {
            return await _collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<T> Save(T t)
        {
            await _collection.InsertOneAsync(t);
            return t;
        }

        public void Delete(T t)
        {
            var filter = Builders<T>.Filter.Eq("_id", t._id);
            _collection.DeleteOneAsync(filter).Wait();
        }

        public async Task<T> Update(T t)
        {
            var filter = Builders<T>.Filter.Eq("_id", t._id);
            return await _collection.FindOneAndReplaceAsync<T>(filter, t);
        }
    }
}
