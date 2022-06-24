using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using PetStore.Domain;
using PetStore.Repository;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PetStore.Tests
{
    [TestFixture]
    [TestOf(typeof(PetStoreRepository))]
    public class PetStoreRepositoryTest 
    {
        private MockPetStoreApi _mockPetStoreApi;
        private PetStoreRepository _petStoreRepository;

        [SetUp]
        public void SetUp()
        {
            _mockPetStoreApi = new MockPetStoreApi();
        }

        [Test]
        public void GetPetByStatusNoRecordsReturned()
        {
            var mock = new Mock<IPetStoreApi>();
            mock.Setup(x => x.GetPetsByStatus(It.IsAny<PetStatus>())).Returns(new List<Pet>());

            _petStoreRepository = new PetStoreRepository(mock.Object);

            var result = _petStoreRepository.GetPetsByStatus(PetStatus.Available);

            Assert.AreEqual(result.Count, 0);
        }

        [Test]
        public void GetPetByStatusRecordsReturned()
        {
            var mock = new Mock<IPetStoreApi>();
            mock.Setup(x => x.GetPetsByStatus(It.IsAny<PetStatus>())).Returns(new List<Pet>()
                {new Pet() {Category = new Category() {Id = 1, Name = "Cat"}, Id = 1, Name = "Kitty"}});

            _petStoreRepository = new PetStoreRepository(mock.Object);

            var result = _petStoreRepository.GetPetsByStatus(PetStatus.Available);

            Assert.AreEqual(result.Count, 1);
        }

        [Test]
        public void GetPetByStatusInCategory()
        {
            var mock = new Mock<IPetStoreApi>();
            mock.Setup(x => x.GetPetsByStatus(It.IsAny<PetStatus>())).Returns(new List<Pet>()
            {
                new Pet() {Category = new Category() {Id = 1, Name = "Cat"}, Id = 1, Name = "Kitty"},
                new Pet() {Category = new Category() {Id = 2, Name = "Cat"}, Id = 2, Name = "Kitty1"},
                new Pet() {Category = new Category() {Id = 3, Name = "Dog"}, Id = 3, Name = "Harvey"}
            });

            _petStoreRepository = new PetStoreRepository(mock.Object);

            var result = _petStoreRepository.GetPetsByStatus(PetStatus.Available);

            Assert.AreEqual(result.Count(x => x.Category.Name == "Dog"), 1);
        }

    }
}
