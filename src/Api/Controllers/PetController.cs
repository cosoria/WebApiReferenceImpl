using System;
using System.Web.Http;
using WebApiReferenceImpl.Core.Logging;
using WebApiReferenceImpl.Models;
using WebApiReferenceImpl.Services;

namespace WebApiReferenceImpl.Controllers
{
    [RoutePrefix(Constants.Routing.Pets.ApiEndPoint)]
    public class PetController : BaseWebApiController
    {
        private readonly PetsService _petService;

        public PetController(PetsService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            try
            {
                var pets = _petService.GetAll();

                return Ok(pets);
            }
            catch (Exception exception)
            {
                Logger.LogException(exception);
                return InternalServerError();
            }
            
        }

        [HttpGet]
        [Route("{name}")]
        public IHttpActionResult Get(string name)
        {
            return NotFound();
        }

        [HttpGet]
        [Route("owners")]
        public IHttpActionResult GetOwners()
        {
            return NotFound();
        }

        [HttpGet]
        [Route("owners/{name}")]
        public IHttpActionResult GetOwner(string name)
        {
            return NotFound();
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post([FromBody] PetModel pet)
        {
            return NotFound();
        }

        [HttpPut]
        [Route("{name}")]
        public IHttpActionResult Put([FromBody] PetModel pet)
        {
            return NotFound();
        }

        [HttpPatch]
        [Route("{name}")]
        public IHttpActionResult Patch([FromBody] PetModel pet)
        {
            return NotFound();
        }

        [HttpHead]
        [Route("{name}")]
        public IHttpActionResult Exist(string name)
        {
            return NotFound();
        }
    }
}