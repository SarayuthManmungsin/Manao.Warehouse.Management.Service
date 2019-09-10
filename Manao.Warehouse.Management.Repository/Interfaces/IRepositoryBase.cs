using Manao.Warehouse.Management.Domain;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manao.Warehouse.Management.Repository
{
    public interface IRepositoryBase<T> where T : class, IDomainBase
    {
        Task<T> Get(ObjectId id);
        Task<T> Save(T item);
        Task<T> Update(T item);
        void Delete(T item);
        Task<IList<T>> Get();
    }
}
