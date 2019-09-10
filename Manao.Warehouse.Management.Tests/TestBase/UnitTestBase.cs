using Manao.Warehouse.Management.IoC;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Manao.Warehouse.Management.BusinessLogic;

namespace Manao.Warehouse.Management.Tests
{
    [TestClass]
    public class UnitTestBase
    {
        // these logics should be init by an inherited class itself
        protected IItemBusinessLogic _itemBusinessLogic;
        protected IItemHistoryBusinessLogic _itemHistoryBusinessLogic;
        protected IManaoUserBusinessLogic _manaoUserBusinessLogic;
        protected IPurchaseOrderBusinessLogic _purchaseOrderBusinessLogic;

        public UnitTestBase()
        {
            UnityConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}
