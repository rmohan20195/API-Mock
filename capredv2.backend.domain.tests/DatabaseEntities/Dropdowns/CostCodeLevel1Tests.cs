using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DatabaseEntities.Dropdowns
{
    [TestFixture]
    public class CostCodeLevel1Test
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var costCodeLevel1 = new CostCodeLevel1DTO()
            {
                Id = Guid.NewGuid(),
                Value = "A10 - Foundations",
                Position = 0
            };
            var response = CostCodeLevel1.MapFromDomainEntity(costCodeLevel1);

            Assert.IsNotNull(response);
            Assert.AreEqual(costCodeLevel1.Id, response.Id);
            Assert.AreEqual(costCodeLevel1.Value, response.Value);
            Assert.AreEqual(costCodeLevel1.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = CostCodeLevel1.MapFromDomainEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
