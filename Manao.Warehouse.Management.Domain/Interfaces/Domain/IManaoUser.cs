namespace Manao.Warehouse.Management.Domain
{
    public interface IManaoUser : IDomainBase
    {
        string Name { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        bool IsActiveDirectoryUser { get; set; }
    }
}
