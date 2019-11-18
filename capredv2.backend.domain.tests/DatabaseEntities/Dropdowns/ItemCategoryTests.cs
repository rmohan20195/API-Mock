using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DatabaseEntities.Dropdowns
{
    [TestFixture]
    public class ItemCategoryTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var itemCategory = new ItemCategoryDTO()
            {
                Id = Guid.NewGuid(),
                Value = "Consultancy Fees",
                Position = 0
            };
            var response = ItemCategory.MapFromDomainEntity(itemCategory);

            Assert.IsNotNull(response);
            Assert.AreEqual(itemCategory.Id, response.Id);
            Assert.AreEqual(itemCategory.Value, response.Value);
            Assert.AreEqual(itemCategory.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = ItemCategory.MapFromDomainEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
