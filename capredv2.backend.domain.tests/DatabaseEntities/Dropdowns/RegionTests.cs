using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DatabaseEntities.Dropdowns
{
    [TestFixture]
    public class RegionTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var region = new RegionDTO()
            {
                Id = Guid.NewGuid(),
                Value = "AMER",
                Position = 0
            };
            var response = Region.MapFromDomainEntity(region);

            Assert.IsNotNull(response);
            Assert.AreEqual(region.Id, response.Id);
            Assert.AreEqual(region.Value, response.Value);
            Assert.AreEqual(region.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = Region.MapFromDomainEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
