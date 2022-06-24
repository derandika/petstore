using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetStore.Domain;

namespace PetStore.Repository
{
    /// <summary>
    /// IPetStoreApi Interface
    /// </summary>
    public interface IPetStoreApi
    {

        /// <summary>
        /// GetPetByStatus method
        /// </summary>
        /// <param name="petStatus"></param>
        /// <returns></returns>
        List<Pet> GetPetsByStatus(PetStatus petStatus);
    }
}
