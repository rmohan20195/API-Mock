using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DomainEntities.Dropdowns
{
    [TestFixture]
    public class WorkPackagesLevel1DTOTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var workPackagesLevel1 = new WorkPackagesLevel1()
            {
                Id= Guid.NewGuid(),
                Value = "Design Consultants",
                Position = 0
            };
            var response = WorkPackagesLevel1DTO.MapFromDatabaseEntity(workPackagesLevel1);

            Assert.IsNotNull(response);
            Assert.AreEqual(workPackagesLevel1.Id, response.Id);
            Assert.AreEqual(workPackagesLevel1.Value, response.Value);
            Assert.AreEqual(workPackagesLevel1.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = WorkPackagesLevel1DTO.MapFromDatabaseEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
