using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DatabaseEntities.Dropdowns
{
    [TestFixture]
    public class RealEstateOrBauTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var realEstateOrBauDTO = new RealEstateOrBauDTO()
            {
                Id = Guid.NewGuid(),
                Value = "AMER",
                Position = 0
            };
            var response = RealEstateOrBau.MapFromDomainEntity(realEstateOrBauDTO);

            Assert.IsNotNull(response);
            Assert.AreEqual(realEstateOrBauDTO.Id, response.Id);
            Assert.AreEqual(realEstateOrBauDTO.Value, response.Value);
            Assert.AreEqual(realEstateOrBauDTO.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = RealEstateOrBau.MapFromDomainEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
