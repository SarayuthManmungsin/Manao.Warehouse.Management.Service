using Manao.Warehouse.Management.Domain;
using Manao.Warehouse.Management.Repository;

namespace Manao.Warehouse.Management.BusinessLogic
{
    public class ItemHistoryBusinessLogic : BusinessLogicBase<IItemHistory>, IItemHistoryBusinessLogic
    {
        private readonly IItemHistoryRepository _itemHistoryRepository;

        public ItemHistoryBusinessLogic(IItemHistoryRepository itemHistoryRepository) : base(itemHistoryRepository)
        {
            _itemHistoryRepository = itemHistoryRepository;
        }
    }
}
