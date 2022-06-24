using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework.Internal;
using PetStore.Domain;
using PetStore.Repository;

namespace PetStore.Tests
{
    public class MockPetStoreApi : Mock<IPetStoreApi>
    {
        public Mock<IPetStoreApi> GivenNoPetRecordsReturned()
        {
            var mock= new Mock<IPetStoreApi>();
            mock.Setup(x => x.GetPetsByStatus(It.IsAny<PetStatus>())).Returns(new List<Pet>());

            return mock;
        }
    }
}
