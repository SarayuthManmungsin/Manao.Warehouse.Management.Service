namespace Manao.Warehouse.Management.Domain
{
    public interface IHistory
    {
        long Date { get; set; }
        IManaoUser By { get; set; }
    }
}
