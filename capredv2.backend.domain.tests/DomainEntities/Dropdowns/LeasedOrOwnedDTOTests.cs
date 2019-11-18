using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DomainEntities.Dropdowns
{
    [TestFixture]
    public class LeasedOrOwnedDTOTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var leasedOrOwned = new LeasedOrOwned()
            {
                Id = Guid.NewGuid(),
                Value = "AMER",
                Position = 0
            };
            var response = LeasedOrOwnedDTO.MapFromDatabaseEntity(leasedOrOwned);

            Assert.IsNotNull(response);
            Assert.AreEqual(leasedOrOwned.Id, response.Id);
            Assert.AreEqual(leasedOrOwned.Value, response.Value);
            Assert.AreEqual(leasedOrOwned.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = LeasedOrOwnedDTO.MapFromDatabaseEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
