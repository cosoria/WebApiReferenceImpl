using System.Web.Http;

namespace WebApiReferenceImpl.Controllers
{
    [RoutePrefix(Constants.Routing.Owners.ApiEndPoint)]
    public class OwnersController : BaseWebApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return NotFound();
        }

        [HttpGet]
        [Route("{name}")]
        public IHttpActionResult Get(string name)
        {
            return NotFound();
        }

        [HttpGet]
        [Route("pets")]
        public IHttpActionResult GetPets()
        {
            return NotFound();
        }

        [HttpGet]
        [Route("pets/{name}")]
        public IHttpActionResult GetPet(string name)
        {
            return NotFound();
        }
    }
}