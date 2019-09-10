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
    public class ItemHistoriesController : ApiControllerBase
    {
        private readonly IItemHistoryBusinessLogic _itemHistoryBusinessLogic;

        public ItemHistoriesController(IItemHistoryBusinessLogic itemHistoryBusinessLogic)
        {
            _itemHistoryBusinessLogic = itemHistoryBusinessLogic;
        }

        public async Task<HttpResponseMessage> Get()
        {
            IList<IItemHistory> histories = await _itemHistoryBusinessLogic.Get();
            return CreateResponse(HttpStatusCode.OK, histories);
        }

        public async Task<HttpResponseMessage> Get(string id)
        {
            IItemHistory history = await _itemHistoryBusinessLogic.Get(ObjectId.Parse(id));
            return CreateResponse(HttpStatusCode.OK, history);
        }

        public async Task<HttpResponseMessage> Put(ItemHistory history)
        {
            IItemHistory updatedHistory = await _itemHistoryBusinessLogic.Update(history);
            return CreateResponse(HttpStatusCode.OK, updatedHistory);
        }

        public async Task<HttpResponseMessage> Post(ItemHistory history)
        {
            IItemHistory createdHistory = await _itemHistoryBusinessLogic.Save(history);
            createdHistory = await _itemHistoryBusinessLogic.Get(createdHistory._id);
            return CreateResponse(HttpStatusCode.Created, history);
        }

        public async Task<HttpResponseMessage> Delete(string id)
        {
            IItemHistory history = await _itemHistoryBusinessLogic.Get(ObjectId.Parse(id));
            _itemHistoryBusinessLogic.Delete(history);
            return CreateResponse(HttpStatusCode.NoContent);
        }
    }
}