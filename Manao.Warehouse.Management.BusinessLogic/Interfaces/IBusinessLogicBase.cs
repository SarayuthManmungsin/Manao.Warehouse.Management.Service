using Manao.Warehouse.Management.Domain;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manao.Warehouse.Management.BusinessLogic
{
    public interface IBusinessLogicBase<T> where T : class, IDomainBase
    {
        Task<T> Get(ObjectId id);
        Task<IList<T>> Get();
        Task<T> Save(T item);
        void Delete(T item);
        Task<T> Update(T item);
    }
}
