using System.Collections.Generic;

namespace Manao.Warehouse.Management.Domain
{
    public interface IPurchaseOrder : IDomainBase
    {
        IList<IItem> Items { get; set; }
        IHistory Purchased { get; set; }
        PurchasingStatus Status { get; set; }
    }
}
