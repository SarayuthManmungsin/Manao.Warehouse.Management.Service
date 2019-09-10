namespace Manao.Warehouse.Management.Domain
{
    public class ItemHistory : Item, IItemHistory
    {
        public virtual int ItemId { get; set; }
        public virtual ActionType ActionType { get; set; }
        public virtual long Date { get; set; }
        public virtual IManaoUser By { get; set; }
    }
}
