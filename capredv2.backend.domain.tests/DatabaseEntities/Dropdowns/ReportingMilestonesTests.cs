using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DatabaseEntities.Dropdowns
{
    [TestFixture]
    public class ReportingMilestonesTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var reportingMilestones = new ReportingMilestonesDTO()
            {
                Id = Guid.NewGuid(),
                Value = "Receive Business Approval",
                Position = 0
            };
            var response = ReportingMilestones.MapFromDomainEntity(reportingMilestones);

            Assert.IsNotNull(response);
            Assert.AreEqual(reportingMilestones.Id, response.Id);
            Assert.AreEqual(reportingMilestones.Value, response.Value);
            Assert.AreEqual(reportingMilestones.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = ReportingMilestones.MapFromDomainEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
