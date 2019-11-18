using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DomainEntities.Dropdowns
{
    [TestFixture]
    public class CipOrNonCipDTOTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var cipOrNonCip = new CipOrNonCip()
            {
                Id = Guid.NewGuid(),
                Value = "CIP",
                Position = 0
            };
            var response = CipOrNonCipDTO.MapFromDatabaseEntity(cipOrNonCip);

            Assert.IsNotNull(response);
            Assert.AreEqual(cipOrNonCip.Id, response.Id);
            Assert.AreEqual(cipOrNonCip.Value, response.Value);
            Assert.AreEqual(cipOrNonCip.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = CipOrNonCipDTO.MapFromDatabaseEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
