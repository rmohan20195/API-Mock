using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DatabaseEntities.Dropdowns
{
    [TestFixture]
    public class ItemStatusTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var itemStatus = new ItemStatusDTO()
            {
                Id = Guid.NewGuid(),
                Value = "AMER",
                Position = 0
            };
            var response = ItemStatus.MapFromDomainEntity(itemStatus);

            Assert.IsNotNull(response);
            Assert.AreEqual(itemStatus.Id, response.Id);
            Assert.AreEqual(itemStatus.Value, response.Value);
            Assert.AreEqual(itemStatus.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = ItemStatus.MapFromDomainEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
