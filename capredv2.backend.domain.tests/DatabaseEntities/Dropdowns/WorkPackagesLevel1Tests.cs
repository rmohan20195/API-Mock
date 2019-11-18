using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DatabaseEntities.Dropdowns
{
    [TestFixture]
    public class WorkPackagesLevel1Tests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var workPackagesLevel1 = new WorkPackagesLevel1DTO()
            {
                Id= Guid.NewGuid(),
                Value = "Design Consultants",
                Position = 0
            };
            var response = WorkPackagesLevel1.MapFromDomainEntity(workPackagesLevel1);

            Assert.IsNotNull(response);
            Assert.AreEqual(workPackagesLevel1.Id, response.Id);
            Assert.AreEqual(workPackagesLevel1.Value, response.Value);
            Assert.AreEqual(workPackagesLevel1.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = WorkPackagesLevel1.MapFromDomainEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
