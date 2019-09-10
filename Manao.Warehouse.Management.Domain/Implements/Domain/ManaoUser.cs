namespace Manao.Warehouse.Management.Domain
{
    public class ManaoUser : DomainBase, IManaoUser, IDomainBase
    {
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual bool IsActiveDirectoryUser { get; set; }
    }
}
