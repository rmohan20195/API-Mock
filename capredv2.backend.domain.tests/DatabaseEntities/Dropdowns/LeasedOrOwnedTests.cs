using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DatabaseEntities.Dropdowns
{
    [TestFixture]
    public class LeasedOrOwnedTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var leasedOrOwned = new LeasedOrOwnedDTO()
            {
                Id = Guid.NewGuid(),
                Value = "AMER",
                Position = 0
            };
            var response = LeasedOrOwned.MapFromDomainEntity(leasedOrOwned);

            Assert.IsNotNull(response);
            Assert.AreEqual(leasedOrOwned.Id, response.Id);
            Assert.AreEqual(leasedOrOwned.Value, response.Value);
            Assert.AreEqual(leasedOrOwned.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = LeasedOrOwned.MapFromDomainEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
