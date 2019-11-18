using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DatabaseEntities.Dropdowns
{
    public class BusinessJustificationTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var businessJustification = new BusinessJustificationDTO()
            {
                Id = Guid.NewGuid(),
                Value = "Required for Project Due Diligence",
                Position = 0
            };
            var response = BusinessJustification.MapFromDomainEntity(businessJustification);

            Assert.IsNotNull(response);
            Assert.AreEqual(businessJustification.Id, response.Id);
            Assert.AreEqual(businessJustification.Value, response.Value);
            Assert.AreEqual(businessJustification.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = BusinessJustification.MapFromDomainEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
