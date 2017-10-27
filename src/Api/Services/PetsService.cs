using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Antlr.Runtime.Misc;
using WebApiReferenceImpl.Models;

namespace WebApiReferenceImpl.Services
{
    public class PetsService
    {
        public IEnumerable<PetModel> GetAll()
        {
            return Enumerable.Empty<PetModel>();
        }

        public PetModel Get(string name)
        {
            return new PetModel();
        }

        public IEnumerable<PetModel> Filter(Expression<Func<PetModel>> filter)
        {
            return Enumerable.Empty<PetModel>();
        }

        public PetModel Add(PetModel pet)
        {
            return new PetModel();
        }
    }
}