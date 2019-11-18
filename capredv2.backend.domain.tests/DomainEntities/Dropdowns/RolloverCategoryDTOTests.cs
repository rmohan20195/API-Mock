using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DomainEntities.Dropdowns
{
    [TestFixture]
    public class RolloverCategoryDTOTests
    {

        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var rolloverCategory = new RolloverCategory()
            {
                Id = Guid.NewGuid(),
                Value = "Pending Submission",
                Position = 0
            };
            var response = RolloverCategoryDTO.MapFromDatabaseEntity(rolloverCategory);

            Assert.IsNotNull(response);
            Assert.AreEqual(rolloverCategory.Id, response.Id);
            Assert.AreEqual(rolloverCategory.Value, response.Value);
            Assert.AreEqual(rolloverCategory.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = RolloverCategoryDTO.MapFromDatabaseEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
