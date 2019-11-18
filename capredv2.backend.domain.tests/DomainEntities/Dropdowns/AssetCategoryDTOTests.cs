using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DomainEntities.Dropdowns
{
    [TestFixture]
    public class AssetCategoryDTOTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var assetCategory = new AssetCategory()
            {
                Id = Guid.NewGuid(),
                Value = "5410105 Amortization lease improvements",
                Position = 0
            };
            var response = AssetCategoryDTO.MapFromDatabaseEntity(assetCategory);

            Assert.IsNotNull(response);
            Assert.AreEqual(assetCategory.Id, response.Id);
            Assert.AreEqual(assetCategory.Value, response.Value);
            Assert.AreEqual(assetCategory.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = AssetCategoryDTO.MapFromDatabaseEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
