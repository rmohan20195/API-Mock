using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DomainEntities.Dropdowns
{
    [TestFixture]
    public class RequiredOrDiscretionaryDTOTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var requiredOrDiscretionary = new RequiredOrDiscretionary()
            {
                Id = Guid.NewGuid(),
                Value = "Required",
                Position = 0
            };
            var response = RequiredOrDiscretionaryDTO.MapFromDatabaseEntity(requiredOrDiscretionary);

            Assert.IsNotNull(response);
            Assert.AreEqual(requiredOrDiscretionary.Id, response.Id);
            Assert.AreEqual(requiredOrDiscretionary.Value, response.Value);
            Assert.AreEqual(requiredOrDiscretionary.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = RequiredOrDiscretionaryDTO.MapFromDatabaseEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
