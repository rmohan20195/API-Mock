using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DomainEntities.Dropdowns
{
    public class BusinessJustificationDTOTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var businessJustification = new BusinessJustification()
            {
                Id = Guid.NewGuid(),
                Value = "Required for Project Due Diligence",
                Position = 0
            };
            var response = BusinessJustificationDTO.MapFromDatabaseEntity(businessJustification);

            Assert.IsNotNull(response);
            Assert.AreEqual(businessJustification.Id, response.Id);
            Assert.AreEqual(businessJustification.Value, response.Value);
            Assert.AreEqual(businessJustification.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = BusinessJustificationDTO.MapFromDatabaseEntity(null);
            
            //Assert
            Assert.IsNull(response);
        }
    }
}
