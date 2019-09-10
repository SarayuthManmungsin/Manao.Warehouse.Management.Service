namespace Manao.Warehouse.Management.Domain
{
    public class Item : DomainBase, IItem
    {
        public virtual string Name { get; set; }
        public virtual int Amount { get; set; }
        public virtual double RetailPrice { get; set; }
        public virtual double WholesalePrice { get; set; }
        public virtual ItemType Type { get; set; }
    }
}