namespace Manao.Warehouse.Management.Domain
{
    public interface IItem : IDomainBase
    {
        string Name { get; set; }
        int Amount { get; set; }
        double RetailPrice { get; set; }
        double WholesalePrice { get; set; }
        ItemType Type { get; set; }
    }
}
