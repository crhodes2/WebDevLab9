﻿using System;
using NUnit.Framework;
using FakeItEasy;
using WebDevLab9.Data.Entities;
using WebDevLab9.Repositories;
using WebDevLab9.Services;

namespace WebDevLab9.Tests
{
    [TestFixture]
    public class PetServiceTests
    {
        private IPetRepository _petRespository;

        [SetUp]
        public void SetUp()
        {
            _petRespository = A.Fake<IPetRepository>();
        }

        [Test]
        public void ShouldNotIndicateCheckupAlert()
        {
            // Arrange
            A.CallTo(() => _petRespository.GetPet(A<int>.Ignored)).Returns(new Pet
            {
                NextCheckup = DateTime.Now.AddDays(29)
            });

            // Act (SUT)
            var petService = new PetService(_petRespository);
            var petViewModel = petService.GetPet(1);

            // Assert
            Assert.IsFalse(petViewModel.CheckupAlert);
        }

        [Test]
        public void ShouldIndicateCheckupAlert()
        {
            // Arrange
            A.CallTo(() => _petRespository.GetPet(A<int>.Ignored)).Returns(new Pet
            {
                NextCheckup = DateTime.Now.AddDays(13)
            });

            // Act (SUT)
            var petService = new PetService(_petRespository);
            var petViewModel = petService.GetPet(1);

            // Assert
            Assert.IsTrue(petViewModel.CheckupAlert);
        }
    }
}
