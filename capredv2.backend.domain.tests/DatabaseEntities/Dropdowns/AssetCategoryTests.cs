using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DatabaseEntities.Dropdowns
{
    [TestFixture]
    public class AssetCategoryTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var assetCategory = new AssetCategoryDTO()
            {
                Id = Guid.NewGuid(),
                Value = "5410105 Amortization lease improvements",
                Position = 0
            };
            var response = AssetCategory.MapFromDomainEntity(assetCategory);

            Assert.IsNotNull(response);
            Assert.AreEqual(assetCategory.Id, response.Id);
            Assert.AreEqual(assetCategory.Value, response.Value);
            Assert.AreEqual(assetCategory.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = AssetCategory.MapFromDomainEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
