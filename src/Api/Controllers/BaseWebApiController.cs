using System.Web.Http;
using WebApiReferenceImpl.Models;
using WebApiReferenceImpl.Core.Logging;

namespace WebApiReferenceImpl.Controllers
{
    public abstract class BaseWebApiController : ApiController
    {
        private IModelFactory _modelFactory;
        private IModelValidator _modelValidator;
        private ILogger _logger;

        public IModelFactory ModelFactory 
        {
            get 
            { 
                return _modelFactory ?? (_modelFactory = new ModelFactory(this.Request)); 
            }
        }

        public IModelValidator ModelValidator
        {
            get
            {
                return _modelValidator ?? (_modelValidator = new ModelValidator(this.Request));
            }
        }

        public ILogger Logger
        {
            get
            {
                return _logger ?? (_logger = new NullLogger());
            }
        }
    }
}