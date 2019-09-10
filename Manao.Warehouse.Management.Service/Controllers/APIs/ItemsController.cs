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
    public class ItemsController : ApiControllerBase
    {
        private readonly IItemBusinessLogic _itemBusinessLogic;

        public ItemsController(IItemBusinessLogic itemBusinessLogic)
        {
            _itemBusinessLogic = itemBusinessLogic;
        }

        public async Task<HttpResponseMessage> Get()
        {
            IList<IItem> items = await _itemBusinessLogic.Get();
            return CreateResponse(HttpStatusCode.OK, items);
        }

        public async Task<HttpResponseMessage> Get(string id)
        {
            IItem item = await _itemBusinessLogic.Get(ObjectId.Parse(id));
            return CreateResponse(HttpStatusCode.OK, item);
        }

        public async Task<HttpResponseMessage> Put(Item item)
        {
            IItem updatedItem = await _itemBusinessLogic.Update(item);
            return CreateResponse(HttpStatusCode.OK, updatedItem);
        }

        public async Task<HttpResponseMessage> Post(Item item)
        {
            IItem createdItem = await _itemBusinessLogic.Save(item);
            createdItem = await _itemBusinessLogic.Get(createdItem._id);
            return CreateResponse(HttpStatusCode.Created, item);
        }

        public async Task<HttpResponseMessage> Delete(string id)
        {
            IItem item = await _itemBusinessLogic.Get(ObjectId.Parse(id));
            _itemBusinessLogic.Delete(item);
            return CreateResponse(HttpStatusCode.NoContent, item);
        }
    }
}