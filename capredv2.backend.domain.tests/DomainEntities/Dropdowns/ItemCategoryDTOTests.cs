using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DomainEntities.Dropdowns
{
    [TestFixture]
    public class ItemCategoryDTOTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var itemCategory = new ItemCategory()
            {
                Id = Guid.NewGuid(),
                Value = "Consultancy Fees",
                Position = 0
            };
            var response = ItemCategoryDTO.MapFromDatabaseEntity(itemCategory);

            Assert.IsNotNull(response);
            Assert.AreEqual(itemCategory.Id, response.Id);
            Assert.AreEqual(itemCategory.Value, response.Value);
            Assert.AreEqual(itemCategory.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = ItemCategoryDTO.MapFromDatabaseEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
