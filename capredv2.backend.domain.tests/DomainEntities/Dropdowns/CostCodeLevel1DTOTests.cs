using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DomainEntities.Dropdowns
{
    [TestFixture]
    public class CostCodeLevel1DTOTest
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var costCodeLevel1 = new CostCodeLevel1()
            {
                Id = Guid.NewGuid(),
                Value = "A10 - Foundations",
                Position = 0
            };
            var response = CostCodeLevel1DTO.MapFromDatabaseEntity(costCodeLevel1);

            Assert.IsNotNull(response);
            Assert.AreEqual(costCodeLevel1.Id, response.Id);
            Assert.AreEqual(costCodeLevel1.Value, response.Value);
            Assert.AreEqual(costCodeLevel1.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = CostCodeLevel1DTO.MapFromDatabaseEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
