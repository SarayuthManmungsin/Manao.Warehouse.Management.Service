using Manao.Warehouse.Management.BusinessLogic;
using Manao.Warehouse.Management.DataAccess;
using Manao.Warehouse.Management.Repository;
using System;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Manao.Warehouse.Management.IoC
{
    public class UnityConfig
    {
        private static UnityContainer _container;

        public static Func<UnityContainer> Register(HttpConfiguration config)
        {
            _container = new UnityContainer();

            _container.RegisterType<IUnitOfWork, UnitOfWork>();
            _container.RegisterType<IMongoDB, DataAccess.MongoDB>();

            _container.RegisterType<IItemRepository, ItemRepository>();
            _container.RegisterType<IItemHistoryRepository, ItemHistoryRepository>();
            _container.RegisterType<IManaoUserRepository, ManaoUserRepository>();
            _container.RegisterType<IPurchaseOrderRepository, PurchaseOrderRepository>();

            _container.RegisterType<IItemBusinessLogic, ItemBusinessLogic>();
            _container.RegisterType<IItemHistoryBusinessLogic, ItemHistoryBusinessLogic>();
            _container.RegisterType<IManaoUserBusinessLogic, ManaoUserBusinessLogic>();
            _container.RegisterType<IPurchaseOrderBusinessLogic, PurchaseOrderBusinessLogic>();

            config.DependencyResolver = new UnityDependencyResolver(_container);

            return InitContainer;
        }

        private static UnityContainer InitContainer()
        {
            return _container;
        }
    }
}
