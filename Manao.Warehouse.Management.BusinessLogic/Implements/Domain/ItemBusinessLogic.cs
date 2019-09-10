using Manao.Warehouse.Management.Domain;
using Manao.Warehouse.Management.Repository;

namespace Manao.Warehouse.Management.BusinessLogic
{
    public class ItemBusinessLogic : BusinessLogicBase<IItem>, IItemBusinessLogic
    {
        private readonly IItemRepository _itemRepository;

        public ItemBusinessLogic(IItemRepository itemRepository) : base(itemRepository)
        {
            _itemRepository = itemRepository;
        }
    }
}
