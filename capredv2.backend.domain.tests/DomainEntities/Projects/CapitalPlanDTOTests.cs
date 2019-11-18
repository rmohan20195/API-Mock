using System;
using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DomainEntities.Projects;
using NUnit.Framework;

namespace capredv2.backend.domain.tests.DomainEntities.Projects
{
    [TestFixture]
    public class CapitalPlanDTOTests
    {
        [Test]
        public void MapFromDatabaseEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var capitalPlan = new CapitalPlan
            {
                Id = Guid.NewGuid(),
                ProjectId = new Guid("b58b6a58-2064-4c71-9b3d-c8c4514159a9"),
                Priority = 1,
                Rollover = false,
                RolloverCategory = 0,
                PartOfPBASubmission = false,
                BusinessPriority = 1,
                Theme = "Theme",
                BusinessDriver = "Business Driver",
                Group = "Group",
                LeaseExpiry = "Lease Expiry",
                StartDate = new DateTime(2018, 08, 01),
                EndDate = new DateTime(2020, 08,01),
                RiskToBusinessByNotDoingIt = "Risk to Business",
                BusinessRequirementsDone = false,
                Comments = "Comments"
            };

            //Act
            var response = CapitalPlanDTO.MapFromDatabaseEntity(capitalPlan);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(capitalPlan.Id, response.Id);
            Assert.AreEqual(capitalPlan.ProjectId, response.ProjectId);
            Assert.AreEqual(capitalPlan.Priority, response.Priority);
            Assert.AreEqual(capitalPlan.Rollover, response.Rollover);
            Assert.AreEqual(capitalPlan.RolloverCategory, response.RolloverCategory);
            Assert.AreEqual(capitalPlan.PartOfPBASubmission, response.PartOfPBASubmission);
            Assert.AreEqual(capitalPlan.BusinessPriority, response.BusinessPriority);
            Assert.AreEqual(capitalPlan.Theme, response.Theme);
            Assert.AreEqual(capitalPlan.BusinessDriver, response.BusinessDriver);
            Assert.AreEqual(capitalPlan.Group, response.Group);
            Assert.AreEqual(capitalPlan.LeaseExpiry, response.LeaseExpiry);
            Assert.AreEqual(capitalPlan.StartDate, response.StartDate);
            Assert.AreEqual(capitalPlan.EndDate, response.EndDate);
            Assert.AreEqual(capitalPlan.RiskToBusinessByNotDoingIt, response.RiskToBusinessByNotDoingIt);
            Assert.AreEqual(capitalPlan.BusinessRequirementsDone, response.BusinessRequirementsDone);
            Assert.AreEqual(capitalPlan.Comments, response.Comments);
        }

        [Test]
        public void MapFromDatabaseEntity_NullContent_ReturnNull()
        {
            //Act
            var response = CapitalPlanDTO.MapFromDatabaseEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
