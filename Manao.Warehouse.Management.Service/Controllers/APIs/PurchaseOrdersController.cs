using Manao.Warehouse.Management.BusinessLogic;
using Manao.Warehouse.Management.Domain;
using Manao.Warehouse.Management.Utils;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Manao.Warehouse.Management.Service.Controllers.APIs
{
    public class PurchaseOrdersController : ApiControllerBase
    {
        private readonly IPurchaseOrderBusinessLogic _purchaseOrderBusinessLogic;

        public PurchaseOrdersController(IPurchaseOrderBusinessLogic purchaseOrderBusinessLogic)
        {
            _purchaseOrderBusinessLogic = purchaseOrderBusinessLogic;
        }

        public async Task<HttpResponseMessage> Get()
        {
            IList<IPurchaseOrder> purchaseOrders = await _purchaseOrderBusinessLogic.Get();
            return CreateResponse(HttpStatusCode.OK, purchaseOrders);
        }

        public async Task<HttpResponseMessage> Get(string id)
        {
            IPurchaseOrder purchaseOrder = await _purchaseOrderBusinessLogic.Get(ObjectId.Parse(id));
            return CreateResponse(HttpStatusCode.OK, purchaseOrder);
        }

        public async Task<HttpResponseMessage> Put(PurchaseOrder purchaseOrder)
        {
            IPurchaseOrder updatedOrder = await _purchaseOrderBusinessLogic.Update(purchaseOrder);
            return CreateResponse(HttpStatusCode.OK, purchaseOrder);
        }

        public async Task<HttpResponseMessage> Post(PurchaseOrder purchaseOrder)
        {
            IPurchaseOrder createdOrder = await _purchaseOrderBusinessLogic.Save(purchaseOrder);
            createdOrder = await _purchaseOrderBusinessLogic.Get(createdOrder._id);
            return CreateResponse(HttpStatusCode.Created, createdOrder);
        }

        public async Task<HttpResponseMessage> Delete(string id)
        {
            IPurchaseOrder purchaseOrder = await _purchaseOrderBusinessLogic.Get(ObjectId.Parse(id));
            _purchaseOrderBusinessLogic.Delete(purchaseOrder);
            return CreateResponse(HttpStatusCode.NoContent);
        }
    }
}