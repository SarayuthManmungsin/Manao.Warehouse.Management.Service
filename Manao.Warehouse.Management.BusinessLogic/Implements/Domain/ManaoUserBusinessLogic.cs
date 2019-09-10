using Manao.Warehouse.Management.Domain;
using Manao.Warehouse.Management.Repository;

namespace Manao.Warehouse.Management.BusinessLogic
{
    public class ManaoUserBusinessLogic : BusinessLogicBase<IManaoUser>, IManaoUserBusinessLogic
    {
        private readonly IManaoUserRepository _manaoUserRepository;

        public ManaoUserBusinessLogic(IManaoUserRepository manaoUserRepository) : base(manaoUserRepository)
        {
            _manaoUserRepository = manaoUserRepository;
        }
    }
}
