using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DomainEntities.Dropdowns
{
    [TestFixture]
    public class ReportingMilestonesDTOTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var reportingMilestones = new ReportingMilestones()
            {
                Id = Guid.NewGuid(),
                Value = "Receive Business Approval",
                Position = 0
            };
            var response = ReportingMilestonesDTO.MapFromDatabaseEntity(reportingMilestones);

            Assert.IsNotNull(response);
            Assert.AreEqual(reportingMilestones.Id, response.Id);
            Assert.AreEqual(reportingMilestones.Value, response.Value);
            Assert.AreEqual(reportingMilestones.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = ReportingMilestonesDTO.MapFromDatabaseEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
