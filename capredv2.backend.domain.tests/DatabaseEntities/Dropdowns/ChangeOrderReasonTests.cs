using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DatabaseEntities.Dropdowns
{
    [TestFixture]
    public class ChangeOrderReasonTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var changeOrderReason = new ChangeOrderReasonDTO()
            {
                Id = Guid.NewGuid(),
                Value = "Client Design Change",
                Position = 0
            };
            var response = ChangeOrderReason.MapFromDomainEntity(changeOrderReason);

            Assert.IsNotNull(response);
            Assert.AreEqual(changeOrderReason.Id, response.Id);
            Assert.AreEqual(changeOrderReason.Value, response.Value);
            Assert.AreEqual(changeOrderReason.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = ChangeOrderReason.MapFromDomainEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
