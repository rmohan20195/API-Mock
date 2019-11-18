using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DatabaseEntities.Dropdowns
{
    [TestFixture]
    public class PlanProjectOrEmergingTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var planProjectOrEmerging = new PlanProjectOrEmergingDTO()
            {
                Id = Guid.NewGuid(),
                Value = "Plan Project",
                Position = 0
            };
            var response = PlanProjectOrEmerging.MapFromDomainEntity(planProjectOrEmerging);

            Assert.IsNotNull(response);
            Assert.AreEqual(planProjectOrEmerging.Id, response.Id);
            Assert.AreEqual(planProjectOrEmerging.Value, response.Value);
            Assert.AreEqual(planProjectOrEmerging.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = PlanProjectOrEmerging.MapFromDomainEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
