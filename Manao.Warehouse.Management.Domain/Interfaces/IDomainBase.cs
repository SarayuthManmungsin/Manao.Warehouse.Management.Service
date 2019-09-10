using MongoDB.Bson;

namespace Manao.Warehouse.Management.Domain
{
    public interface IDomainBase
    {
        ObjectId _id { get; }
        bool IsActive { get; set; }

        string Details { get; set; }
    }
}
