using Manao.Warehouse.Management.Domain;
using Manao.Warehouse.Management.Repository;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manao.Warehouse.Management.BusinessLogic
{
    public class BusinessLogicBase<T> : IBusinessLogicBase<T> where T : class, IDomainBase
    {
        //private readonly IRepositoryBase<T> _repository = ObjectFactory.GetInstance<IRepositoryBase<T>>();
        private readonly IRepositoryBase<T> _repository;

        public BusinessLogicBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public virtual Task<T> Get(ObjectId id)
        {
            return _repository.Get(id);
        }

        public virtual Task<IList<T>> Get()
        {
            return _repository.Get();
        }

        public virtual Task<T> Save(T item)
        {
            return _repository.Save(item);
        }

        public virtual void Delete(T item)
        {
            _repository.Delete((T)item);
        }

        public virtual Task<T> Update(T item)
        {
            return _repository.Update((T)item);
        }
    }
}
