using System.Collections.Generic;

namespace Manao.Warehouse.Management.Domain
{
    public class PurchaseOrder : DomainBase, IPurchaseOrder
    {
        public virtual IList<IItem> Items { get; set; }
        public virtual IHistory Purchased { get; set; }
        public virtual PurchasingStatus Status { get; set; }
    }
}
