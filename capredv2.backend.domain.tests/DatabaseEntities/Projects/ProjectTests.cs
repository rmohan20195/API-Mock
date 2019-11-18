using System;
using System.Collections.Generic;
using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DomainEntities.Projects;
using NUnit.Framework;

namespace capredv2.backend.domain.tests.DatabaseEntities.Projects
{
    [TestFixture]
    public class ProjectTests
    {
        [Test]
        public void MapFromDomainEntity_ValidProject_ReturnValidProjectDTO()
        {
            //Arrange
            var project = new ProjectDTO
            {
                Id = new Guid("b58b6a58-2064-4c71-9b3d-c8c4514159a9"),
                ProjectInformation = new ProjectInformationDTO(),
                CapitalPlan = new CapitalPlanDTO(),
                //Estimate = new EstimateDTO(),
                RequisitionHeaders = new List<RequisitionHeaderDTO>(),
                POHeaders = new List<POHeaderDTO>(),
                InvoiceHeaders = new List<InvoiceHeaderDTO>(),
                //ScheduleDate = new ScheduleDateDTO(),
                //BudgetMovementLog = new BudgetMovementLogDTO()
            };

            //Act
            var result = Project.MapFromDomainEntity(project);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(project.Id, result.Id);
            Assert.IsNotNull(result.ProjectInformation);
            Assert.IsNotNull(result.CapitalPlan);
            //Assert.IsNotNull(result.Estimate);
            Assert.IsNotNull(result.RequisitionHeaders);
            Assert.IsNotNull(result.POHeaders);
            Assert.IsNotNull(result.InvoiceHeaders);
            //Assert.IsNotNull(result.ScheduleDate);
            //Assert.IsNotNull(result.BudgetMovementLog);
        }

        [Test]
        public void MapFromDomainEntity_NullProject_ReturnNull()
        {
            //Act
            var result = Project.MapFromDomainEntity(null);

            //Assert
            Assert.IsNull(result);
        }
    }
}
