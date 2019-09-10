namespace Manao.Warehouse.Management.Domain
{
    public class History : IHistory
    {
        public virtual long Date { get; set; }
        public virtual IManaoUser By { get; set; }
    }
}
