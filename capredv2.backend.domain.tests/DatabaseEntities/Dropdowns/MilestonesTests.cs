using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DatabaseEntities.Dropdowns
{
    [TestFixture]
    public class MilestonesTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var milestones = new MilestonesDTO()
            {
                Id = Guid.NewGuid(),
                Value = "AMER",
                Position = 0
            };
            var response = Milestones.MapFromDomainEntity(milestones);

            Assert.IsNotNull(response);
            Assert.AreEqual(milestones.Id, response.Id);
            Assert.AreEqual(milestones.Value, response.Value);
            Assert.AreEqual(milestones.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = Milestones.MapFromDomainEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
