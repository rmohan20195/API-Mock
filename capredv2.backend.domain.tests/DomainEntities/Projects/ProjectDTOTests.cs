using System;
using System.Collections.Generic;
using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DomainEntities.Projects;
using NUnit.Framework;

namespace capredv2.backend.domain.tests.DomainEntities.Projects
{
    [TestFixture]
    public class ProjectDTOTests
    {
        [Test]
        public void MapFromDatabaseEntity_ValidProject_ReturnValidProjectDTO()
        {
            //Arrange
            var project = new Project
            {
                Id = new Guid("b58b6a58-2064-4c71-9b3d-c8c4514159a9"),
                ProjectInformation = new ProjectInformation(),
                CapitalPlan = new CapitalPlan(),
                //Estimate = new Estimate(),
                RequisitionHeaders = new List<RequisitionHeader>(),
                POHeaders = new List<POHeader>(),
                InvoiceHeaders = new List<InvoiceHeader>(),
                //ScheduleDate = new ScheduleDate(),
                //BudgetMovementLog = new BudgetMovementLog()
            };

            //Act
            var result = ProjectDTO.MapFromDatabaseEntity(project);

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
        public void MapFromDatabaseEntity_NullProject_ReturnNull()
        {
            //Act
            var result = ProjectDTO.MapFromDatabaseEntity(null);

            //Assert
            Assert.IsNull(result);
        }
    }
}
