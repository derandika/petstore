using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetStore.Domain;

namespace PetStore.Repository
{
    public class PetStoreRepository : IPetStoreRepository
    {
        private readonly IPetStoreApi _petStoreApi;

        public PetStoreRepository(IPetStoreApi iPetStoreApi)
        {
            _petStoreApi = iPetStoreApi;
        }

        public List<Pet> GetPetsByStatus(PetStatus petStatus)
        {
            return _petStoreApi.GetPetsByStatus(petStatus);
        }
    }
}
