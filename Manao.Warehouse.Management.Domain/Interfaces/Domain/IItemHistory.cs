namespace Manao.Warehouse.Management.Domain
{
    // zero-to-one
    public interface IItemHistory : IHistory, IItem
    {
        int ItemId { get; set; }
        ActionType ActionType { get; set; }
    }
}
