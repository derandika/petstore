using System;
using System.Collections.Generic;
using System.Linq;
using PetStore.Domain;
using PetStore.Repository;

namespace PetStore
{
    class Program
    {
        private static IPetStoreRepository _petStoreRepository;
        
        /// <summary>
        /// Console Main 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                _petStoreRepository = new PetStoreRepository(new PetStoreApi());

                List<Pet> pets = GetPetsByStatus(PetStatus.Available);

                DisplayPets(pets);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
            }
        }

        /// <summary>
        /// Get pets by status  
        /// </summary>
        /// <param name="status">Pet Status</param>
        /// <returns>list of pets</returns>
        private static List<Pet> GetPetsByStatus(PetStatus status)
        {
            return _petStoreRepository.GetPetsByStatus(status);
        }

        /// <summary>
        /// Display Pets
        /// </summary>
        /// <param name="pets"></param>
        private static void DisplayPets(List<Pet> pets)
        {
            var results = pets.Where(p => p.Category != null).GroupBy(x => x.Category.Name)
                .Select(x => (Category: x.Key, Pets: x.Select(p => p).ToList())
                ).ToList();

            foreach (var category in results.OrderByDescending(x=> x.Category))
            {
                Console.WriteLine(category.Category);
                Console.WriteLine("-------------------------------------");

                foreach (var p in category.Pets)
                {
                    Console.WriteLine(p.Name);
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
