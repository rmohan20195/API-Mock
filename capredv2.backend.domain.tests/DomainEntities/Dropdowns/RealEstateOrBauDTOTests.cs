using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DomainEntities.Dropdowns
{
    [TestFixture]
    public class RealEstateOrBauDTOTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var realEstateOrBauDTO = new RealEstateOrBau()
            {
                Id = Guid.NewGuid(),
                Value = "AMER",
                Position = 0
            };
            var response = RealEstateOrBauDTO.MapFromDatabaseEntity(realEstateOrBauDTO);

            Assert.IsNotNull(response);
            Assert.AreEqual(realEstateOrBauDTO.Id, response.Id);
            Assert.AreEqual(realEstateOrBauDTO.Value, response.Value);
            Assert.AreEqual(realEstateOrBauDTO.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = RealEstateOrBauDTO.MapFromDatabaseEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
