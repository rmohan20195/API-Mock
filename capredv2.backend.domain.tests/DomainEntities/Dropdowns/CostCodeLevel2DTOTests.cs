using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DomainEntities.Dropdowns
{
    [TestFixture]
    public class CostCodeLevel2DTOTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var costCodeLevel2 = new CostCodeLevel2()
            {
                Id = Guid.NewGuid(),
                Value = "A1030 - Slab Construction",
                Position = 2
            };
            var response = CostCodeLevel2DTO.MapFromDatabaseEntity(costCodeLevel2);

            Assert.IsNotNull(response);
            Assert.AreEqual(costCodeLevel2.Id, response.Id);
            Assert.AreEqual(costCodeLevel2.Value, response.Value);
            Assert.AreEqual(costCodeLevel2.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = CostCodeLevel2DTO.MapFromDatabaseEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
