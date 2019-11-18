using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DatabaseEntities.Dropdowns
{
    [TestFixture]
    public class BusinessRiskTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var businessRisk = new BusinessRiskDTO()
            {
                Id = Guid.NewGuid(),
                Value = "Security",
                Position = 0
            };
            var response = BusinessRisk.MapFromDomainEntity(businessRisk);

            Assert.IsNotNull(response);
            Assert.AreEqual(businessRisk.Id, response.Id);
            Assert.AreEqual(businessRisk.Value, response.Value);
            Assert.AreEqual(businessRisk.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = BusinessRisk.MapFromDomainEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
