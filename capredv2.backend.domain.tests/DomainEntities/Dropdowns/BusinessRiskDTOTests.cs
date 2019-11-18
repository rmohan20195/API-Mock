using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DomainEntities.Dropdowns
{
    [TestFixture]
    public class BusinessRiskDTOTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var businessRisk = new BusinessRisk()
            {
                Id = Guid.NewGuid(),
                Value = "Security",
                Position = 0
            };
            var response = BusinessRiskDTO.MapFromDatabaseEntity(businessRisk);

            Assert.IsNotNull(response);
            Assert.AreEqual(businessRisk.Id, response.Id);
            Assert.AreEqual(businessRisk.Value, response.Value);
            Assert.AreEqual(businessRisk.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = BusinessRiskDTO.MapFromDatabaseEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
