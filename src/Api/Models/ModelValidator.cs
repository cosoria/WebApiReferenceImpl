using System.Net.Http;

namespace WebApiReferenceImpl.Models
{
    public class ModelValidator : IModelValidator
    {
        public ModelValidator(HttpRequestMessage request)
        {
        }
    }
}