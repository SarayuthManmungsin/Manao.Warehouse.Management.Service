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
    public class UsersController : ApiControllerBase
    {
        private readonly IManaoUserBusinessLogic _manaoUserBusinessLogic;

        public UsersController(IManaoUserBusinessLogic manaoUserBusinessLogic)
        {
            _manaoUserBusinessLogic = manaoUserBusinessLogic;
        }

        public async Task<HttpResponseMessage> Get()
        {
            IList<IManaoUser> users = await _manaoUserBusinessLogic.Get();
            return CreateResponse(HttpStatusCode.OK, users);
        }

        public async Task<HttpResponseMessage> Get(string id)
        {
            IManaoUser user = await _manaoUserBusinessLogic.Get(ObjectId.Parse(id));
            return CreateResponse(HttpStatusCode.OK, user);
        }

        public async Task<HttpResponseMessage> Put(ManaoUser user)
        {
            IManaoUser updatedUser = await _manaoUserBusinessLogic.Update(user);
            return CreateResponse(HttpStatusCode.OK, updatedUser);
        }

        public async Task<HttpResponseMessage> Post(ManaoUser user)
        {
            IManaoUser createdUser = await _manaoUserBusinessLogic.Save(user);
            createdUser = await _manaoUserBusinessLogic.Get(createdUser._id);
            return CreateResponse(HttpStatusCode.Created, createdUser);
        }

        public async Task<HttpResponseMessage> Delete(string id)
        {
            IManaoUser user = await _manaoUserBusinessLogic.Get(ObjectId.Parse(id));
            _manaoUserBusinessLogic.Delete(user);
            return CreateResponse(HttpStatusCode.NoContent);
        }
    }
}