using MongoDB.Driver;
using System;

namespace Manao.Warehouse.Management.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IMongoDatabase Database { get; }
        void Commit();
    }
}
