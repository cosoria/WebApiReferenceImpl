using System.Web.Http;

namespace WebApiReferenceImpl.Controllers
{
    [RoutePrefix(Constants.Routing.Clinics.ApiEndPoint)]
    public class ClinicsController : BaseWebApiController
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
        [Route("appointments")]
        public IHttpActionResult GetAppointments()
        {
            return NotFound();
        }

        [HttpGet]
        [Route("appointments/{id}")]
        public IHttpActionResult GetAppointment(string name)
        {
            return NotFound();
        }
    }
}