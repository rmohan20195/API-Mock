using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DatabaseEntities.Dropdowns
{
    [TestFixture]
   public class BusinessDriverTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var businessDriver = new BusinessDriverDTO()
            {
                Id = Guid.NewGuid(),
                Value = "Run",
                Position = 0
            };
            var response = BusinessDriver.MapFromDomainEntity(businessDriver);

            Assert.IsNotNull(response);
            Assert.AreEqual(businessDriver.Id, response.Id);
            Assert.AreEqual(businessDriver.Value, response.Value);
            Assert.AreEqual(businessDriver.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = BusinessDriver.MapFromDomainEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
