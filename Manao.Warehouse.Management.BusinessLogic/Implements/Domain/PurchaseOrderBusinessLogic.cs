using Manao.Warehouse.Management.Domain;
using Manao.Warehouse.Management.Repository;

namespace Manao.Warehouse.Management.BusinessLogic
{
    public class PurchaseOrderBusinessLogic : BusinessLogicBase<IPurchaseOrder>, IPurchaseOrderBusinessLogic
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public PurchaseOrderBusinessLogic(IPurchaseOrderRepository purchaseOrderRepository) : base(purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }
    }
}
