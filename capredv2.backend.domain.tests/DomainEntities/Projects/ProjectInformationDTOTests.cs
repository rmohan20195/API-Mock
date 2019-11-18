using System;
using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DomainEntities.Projects;
using NUnit.Framework;

namespace capredv2.backend.domain.tests.DomainEntities.Projects
{
    [TestFixture]
    public class ProjectInformationDTOTests
    {
        [Test]
        public void MapFromDatabaseEntity_ValidEntity_ReturnValidDTOEntity()
        {
            //Arrange
            var projectInformation = new ProjectInformation
            {
                ProjectId = new Guid("b58b6a58-2064-4c71-9b3d-c8c4514159a9"),
                ProjectName = "Test",
                ProjectDescription = "Test Description",
                Scope = "Scope",
                Region = "region",
                Country = "United States",
                Location = "Location",
                LocationCode = "Location Code",
                EntityCode = "Entity Code",
                Department = "Department",
                Top10Project = "Top 10 Project",
                ProjectStatus = "ProjectStatus",
                ProjectOwner = "ProjectOwner",
                ProjectSponsor = "Project Sponsor",
                BauOrRe = "BAU or RE",
                FiscalYearEnd = 2020,
                BudgetedOrUnbudgeted = "Budgeted",
                CurrentProjectPhase = "Current Project Phase",
                UsableFloorArea = 1400,
                HeadCount = 45,
                LeasedOrOwned = "Leased",
                CapitalExpense = "Capital/Expense",
                FacilityType = "Facility Type",
                ProjectType = "Project Type",
                CriticalityRationale = "Criticality Rationale",
                CriticalityRationaleLevel2 = "Criticality Rationale Level 2",
                RequiredOrDiscretionary = "Required Or Discretionary",
                CurrentLeaseExpiryDate = 2024,
                NewLeaseExpiryDate = 2025,
                OnboardingStatus = "Onboarding Status",
                OnboardingDate = new DateTime(2019, 08, 01),
                OnboardingDeckLink = "Onboarding Deck Link",
                Rollover = true,
                ApprovedBudget = 1012.45D,
                PercentComplete = 35,
                LastUpdated = new DateTime(2019, 08, 08),
                Highlights = "Highlights",
                ActionsNextTwoWeeks = "Action Next Two Weeks",
                RisksAndIssues = "Risks and issues",
                ProjectStartReceiveBusinessRequest = "Project Start Receive Business Request",
                CompleteProjectAnalysis = "Complete Project Analysis",
                SubmitProjectRequestForAnalysis = "Submit Project Request For Analysis",
                CurrentMileStonePercentComplete = 40,
                DesignBriefGatewayDocumentApproval = "Document Approval",
                LeaseExecution = "Lease Execution",
                DesignComplete = "Design Complete",
                PurchaseCeAvTechCircuitsSecurityEquipment = "Purchase CE/AV/Tech/Circuits/Security Equipment",
                AwardOfficeFurnitureContracts = "Award Office",
                StartOnSite = "Start On Site",
                TechnologyRoomMepCommissioningIST = "Technology Room",
                TechnologyRoomHandoverComplete = "Technology Handover",
                CommenceInstallDesktopAndAVEquipment = "Commence Install",
                HandoverToFacilities = "Handover To Facilities",
                CommenceMoveIsAndUse = "Commence Move In",
                InstallationComplete = true,
                ReceiveCloseoutDocumentationAndFinalAccounts = "Receive Closeout",
                ProjectComplete = true
            };

            //Act
            var response = ProjectInformationDTO.MapFromDatabaseEntity(projectInformation);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(projectInformation.ProjectId, response.ProjectId);
            Assert.AreEqual(projectInformation.ProjectName, response.ProjectName);
            Assert.AreEqual(projectInformation.ProjectDescription, response.ProjectDescription);
            Assert.AreEqual(projectInformation.Scope, response.Scope);
            Assert.AreEqual(projectInformation.Region, response.Region);
            Assert.AreEqual(projectInformation.Country, response.Country);
            Assert.AreEqual(projectInformation.Location, response.Location);
            Assert.AreEqual(projectInformation.LocationCode, response.LocationCode);
            Assert.AreEqual(projectInformation.EntityCode, response.EntityCode);
            Assert.AreEqual(projectInformation.Department, response.Department);
            Assert.AreEqual(projectInformation.Top10Project, response.Top10Project);
            Assert.AreEqual(projectInformation.ProjectStatus, response.ProjectStatus);
            Assert.AreEqual(projectInformation.ProjectOwner, response.ProjectOwner);
            Assert.AreEqual(projectInformation.ProjectSponsor, response.ProjectSponsor);
            Assert.AreEqual(projectInformation.BauOrRe, response.BauOrRe);
            Assert.AreEqual(projectInformation.FiscalYearEnd, response.FiscalYearEnd);
            Assert.AreEqual(projectInformation.BudgetedOrUnbudgeted, response.BudgetedOrUnbudgeted);
            Assert.AreEqual(projectInformation.CurrentProjectPhase, response.CurrentProjectPhase);
            Assert.AreEqual(projectInformation.UsableFloorArea, response.UsableFloorArea);
            Assert.AreEqual(projectInformation.HeadCount, response.HeadCount);
            Assert.AreEqual(projectInformation.LeasedOrOwned, response.LeasedOrOwned);
            Assert.AreEqual(projectInformation.CapitalExpense, response.CapitalExpense);
            Assert.AreEqual(projectInformation.FacilityType, response.FacilityType);
            Assert.AreEqual(projectInformation.ProjectType, response.ProjectType);
            Assert.AreEqual(projectInformation.CriticalityRationale, response.CriticalityRationale);
            Assert.AreEqual(projectInformation.CriticalityRationaleLevel2, response.CriticalityRationaleLevel2);
            Assert.AreEqual(projectInformation.RequiredOrDiscretionary, response.RequiredOrDiscretionary);
            Assert.AreEqual(projectInformation.CurrentLeaseExpiryDate, response.CurrentLeaseExpiryDate);
            Assert.AreEqual(projectInformation.NewLeaseExpiryDate, response.NewLeaseExpiryDate);
            Assert.AreEqual(projectInformation.OnboardingStatus, response.OnboardingStatus);
            Assert.AreEqual(projectInformation.OnboardingDate, response.OnboardingDate);
            Assert.AreEqual(projectInformation.OnboardingDeckLink, response.OnboardingDeckLink);
            Assert.AreEqual(projectInformation.Rollover, response.Rollover);
            Assert.AreEqual(projectInformation.ApprovedBudget, response.ApprovedBudget);
            Assert.AreEqual(projectInformation.PercentComplete, response.PercentComplete);
            Assert.AreEqual(projectInformation.LastUpdated, response.LastUpdated);
            Assert.AreEqual(projectInformation.Highlights, response.Highlights);
            Assert.AreEqual(projectInformation.ActionsNextTwoWeeks, response.ActionsNextTwoWeeks);
            Assert.AreEqual(projectInformation.RisksAndIssues, response.RisksAndIssues);
            Assert.AreEqual(projectInformation.ProjectStartReceiveBusinessRequest, response.ProjectStartReceiveBusinessRequest);
            Assert.AreEqual(projectInformation.CompleteProjectAnalysis, response.CompleteProjectAnalysis);
            Assert.AreEqual(projectInformation.SubmitProjectRequestForAnalysis, response.SubmitProjectRequestForAnalysis);
            Assert.AreEqual(projectInformation.CurrentMileStonePercentComplete, response.CurrentMileStonePercentComplete);
            Assert.AreEqual(projectInformation.DesignBriefGatewayDocumentApproval, response.DesignBriefGatewayDocumentApproval);
            Assert.AreEqual(projectInformation.LeaseExecution, response.LeaseExecution);
            Assert.AreEqual(projectInformation.DesignComplete, response.DesignComplete);
            Assert.AreEqual(projectInformation.PurchaseCeAvTechCircuitsSecurityEquipment, response.PurchaseCeAvTechCircuitsSecurityEquipment);
            Assert.AreEqual(projectInformation.AwardOfficeFurnitureContracts, response.AwardOfficeFurnitureContracts);
            Assert.AreEqual(projectInformation.StartOnSite, response.StartOnSite);
            Assert.AreEqual(projectInformation.TechnologyRoomMepCommissioningIST, response.TechnologyRoomMepCommissioningIST);
            Assert.AreEqual(projectInformation.TechnologyRoomHandoverComplete, response.TechnologyRoomHandoverComplete);
            Assert.AreEqual(projectInformation.CommenceInstallDesktopAndAVEquipment, response.CommenceInstallDesktopAndAVEquipment);
            Assert.AreEqual(projectInformation.HandoverToFacilities, response.HandoverToFacilities);
            Assert.AreEqual(projectInformation.CommenceMoveIsAndUse, response.CommenceMoveIsAndUse);
            Assert.AreEqual(projectInformation.InstallationComplete, response.InstallationComplete);
            Assert.AreEqual(projectInformation.ReceiveCloseoutDocumentationAndFinalAccounts, response.ReceiveCloseoutDocumentationAndFinalAccounts);
            Assert.AreEqual(projectInformation.ProjectComplete, response.ProjectComplete);
        }

        [Test]
        public void MapFromDatabaseEntity_NullEntity_ReturnNull()
        {
            //Act
            var response = ProjectInformationDTO.MapFromDatabaseEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
