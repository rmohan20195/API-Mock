using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DomainEntities.Dropdowns
{
    [TestFixture]
    public class FacilityTypeDTOTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var facilityType = new FacilityType()
            {
                Id = Guid.NewGuid(),
                Value = "Headquarters",
                Position = 0
            };
            var response = FacilityTypeDTO.MapFromDatabaseEntity(facilityType);

            Assert.IsNotNull(response);
            Assert.AreEqual(facilityType.Id, response.Id);
            Assert.AreEqual(facilityType.Value, response.Value);
            Assert.AreEqual(facilityType.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = FacilityTypeDTO.MapFromDatabaseEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
