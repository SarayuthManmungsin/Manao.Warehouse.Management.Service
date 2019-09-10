using System;
using System.Threading;
using Unity;

namespace Manao.Warehouse.Management.Utils
{
    public static class ObjectFactory
    {
        private static Lazy<UnityContainer> _containerBuilder;

        public static UnityContainer Container
        {
            get { return _containerBuilder.Value; }
        }

        public static void Initialize(Func<UnityContainer> container)
        {
            _containerBuilder = new Lazy<UnityContainer>(container, LazyThreadSafetyMode.ExecutionAndPublication);
        }

        public static T GetInstance<T>() where T : class
        {
            return Container.Resolve<T>();
        }
    }
}
