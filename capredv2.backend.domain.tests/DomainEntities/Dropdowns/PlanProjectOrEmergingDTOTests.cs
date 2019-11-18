using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DomainEntities.Dropdowns
{
    [TestFixture]
    public class PlanProjectOrEmergingDTOTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var planProjectOrEmerging = new PlanProjectOrEmerging()
            {
                Id = Guid.NewGuid(),
                Value = "Plan Project",
                Position = 0
            };
            var response = PlanProjectOrEmergingDTO.MapFromDatabaseEntity(planProjectOrEmerging);

            Assert.IsNotNull(response);
            Assert.AreEqual(planProjectOrEmerging.Id, response.Id);
            Assert.AreEqual(planProjectOrEmerging.Value, response.Value);
            Assert.AreEqual(planProjectOrEmerging.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = PlanProjectOrEmergingDTO.MapFromDatabaseEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
