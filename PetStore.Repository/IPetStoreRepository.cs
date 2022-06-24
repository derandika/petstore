using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetStore.Domain;

namespace PetStore.Repository
{
    /// <summary>
    /// IPetStoreRepository
    /// </summary>
    public interface IPetStoreRepository
    {
        /// <summary>
        /// GetPetsByStatus method
        /// </summary>
        /// <param name="petStatus">petstatus enum</param>
        /// <returns>list of pets</returns>
        List<Pet> GetPetsByStatus(PetStatus petStatus);
    }
}
