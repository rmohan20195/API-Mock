using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DatabaseEntities.Dropdowns
{
    [TestFixture]
    public class RequiredOrDiscretionaryTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var requiredOrDiscretionary = new RequiredOrDiscretionaryDTO()
            {
                Id = Guid.NewGuid(),
                Value = "Required",
                Position = 0
            };
            var response = RequiredOrDiscretionary.MapFromDomainEntity(requiredOrDiscretionary);

            Assert.IsNotNull(response);
            Assert.AreEqual(requiredOrDiscretionary.Id, response.Id);
            Assert.AreEqual(requiredOrDiscretionary.Value, response.Value);
            Assert.AreEqual(requiredOrDiscretionary.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = RequiredOrDiscretionary.MapFromDomainEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
