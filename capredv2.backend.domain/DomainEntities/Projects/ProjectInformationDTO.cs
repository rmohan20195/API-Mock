using System;
using capredv2.backend.domain.DatabaseEntities.Projects;

namespace capredv2.backend.domain.DomainEntities.Projects
{
    public class ProjectInformationDTO
    {
        //public ProjectInformationDTO()
        //{
        //    LastUpdated = DateTime.Now;
        //}
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string Scope { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string LocationCode { get; set; }
        public string EntityCode { get; set; }
        public string Department { get; set; }
        public string Top10Project { get; set; }
        public string ProjectStatus { get; set; }
        public string ProjectOwner { get; set; }
        public string ProjectSponsor { get; set; }
        public string BauOrRe { get; set; }
        public int FiscalYearEnd { get; set; }
        public string BudgetedOrUnbudgeted { get; set; }
        public string CurrentProjectPhase { get; set; }
        public int UsableFloorArea { get; set; }
        public int HeadCount { get; set; }
        public string LeasedOrOwned { get; set; }
        public string CapitalExpense { get; set; }
        public string FacilityType { get; set; }
        public string ProjectType { get; set; }
        public string CriticalityRationale { get; set; }
        public string CriticalityRationaleLevel2 { get; set; }
        public string RequiredOrDiscretionary { get; set; }
        public int CurrentLeaseExpiryDate { get; set; }
        public int NewLeaseExpiryDate { get; set; }
        public string OnboardingStatus { get; set; }
        public DateTime OnboardingDate { get; set; }
        public string OnboardingDeckLink { get; set; }
        public bool Rollover { get; set; }
        public double ApprovedBudget { get; set; }
        public int PercentComplete { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Highlights { get; set; }
        public string ActionsNextTwoWeeks { get; set; }
        public string RisksAndIssues { get; set; }
        public string ProjectStartReceiveBusinessRequest { get; set; }
        public string CompleteProjectAnalysis { get; set; }
        public string SubmitProjectRequestForAnalysis { get; set; }
        public int CurrentMileStonePercentComplete { get; set; }
        public string DesignBriefGatewayDocumentApproval { get; set; }
        public string LeaseExecution { get; set; }
        public string DesignComplete { get; set; }
        public string PurchaseCeAvTechCircuitsSecurityEquipment { get; set; }
        public string AwardOfficeFurnitureContracts { get; set; }
        public string StartOnSite { get; set; }
        public string TechnologyRoomMepCommissioningIST { get; set; }
        public string TechnologyRoomHandoverComplete { get; set; }
        public string CommenceInstallDesktopAndAVEquipment { get; set; }
        public string HandoverToFacilities { get; set; }
        public string CommenceMoveIsAndUse { get; set; }
        public bool InstallationComplete { get; set; }
        public string ReceiveCloseoutDocumentationAndFinalAccounts { get; set; }
        public bool ProjectComplete { get; set; }

        public static ProjectInformationDTO MapFromDatabaseEntity(ProjectInformation projectProjectInformation)
        {
            if (projectProjectInformation == null) return null;

            return new ProjectInformationDTO
            {
                Highlights = projectProjectInformation.Highlights,
                InstallationComplete = projectProjectInformation.InstallationComplete,
                LeasedOrOwned = projectProjectInformation.LeasedOrOwned,
                ProjectName = projectProjectInformation.ProjectName,
                StartOnSite = projectProjectInformation.StartOnSite,
                RisksAndIssues = projectProjectInformation.RisksAndIssues,
                Top10Project = projectProjectInformation.Top10Project,
                ActionsNextTwoWeeks = projectProjectInformation.ActionsNextTwoWeeks,
                OnboardingDeckLink = projectProjectInformation.OnboardingDeckLink,
                BudgetedOrUnbudgeted = projectProjectInformation.BudgetedOrUnbudgeted,
                UsableFloorArea = projectProjectInformation.UsableFloorArea,
                OnboardingStatus = projectProjectInformation.OnboardingStatus,
                DesignBriefGatewayDocumentApproval = projectProjectInformation.DesignBriefGatewayDocumentApproval,
                EntityCode = projectProjectInformation.EntityCode,
                Region = projectProjectInformation.Region,
                SubmitProjectRequestForAnalysis = projectProjectInformation.SubmitProjectRequestForAnalysis,
                Department = projectProjectInformation.Department,
                CommenceInstallDesktopAndAVEquipment = projectProjectInformation.CommenceInstallDesktopAndAVEquipment,
                CurrentMileStonePercentComplete = projectProjectInformation.CurrentMileStonePercentComplete,
                ReceiveCloseoutDocumentationAndFinalAccounts = projectProjectInformation.ReceiveCloseoutDocumentationAndFinalAccounts,
                ProjectSponsor = projectProjectInformation.ProjectSponsor,
                CompleteProjectAnalysis = projectProjectInformation.CompleteProjectAnalysis,
                Location = projectProjectInformation.Location,
                NewLeaseExpiryDate = projectProjectInformation.NewLeaseExpiryDate,
                ProjectStatus = projectProjectInformation.ProjectStatus,
                CapitalExpense = projectProjectInformation.CapitalExpense,
                TechnologyRoomHandoverComplete = projectProjectInformation.TechnologyRoomHandoverComplete,
                ProjectOwner = projectProjectInformation.ProjectOwner,
                FiscalYearEnd = projectProjectInformation.FiscalYearEnd,
                DesignComplete = projectProjectInformation.DesignComplete,
                ProjectComplete = projectProjectInformation.ProjectComplete,
                CommenceMoveIsAndUse = projectProjectInformation.CommenceMoveIsAndUse,
                CriticalityRationale = projectProjectInformation.CriticalityRationale,
                LeaseExecution = projectProjectInformation.LeaseExecution,
                OnboardingDate = projectProjectInformation.OnboardingDate,
                ApprovedBudget = projectProjectInformation.ApprovedBudget,
                PurchaseCeAvTechCircuitsSecurityEquipment = projectProjectInformation.PurchaseCeAvTechCircuitsSecurityEquipment,
                ProjectType = projectProjectInformation.ProjectType,
                ProjectDescription = projectProjectInformation.ProjectDescription,
                Country = projectProjectInformation.Country,
                CriticalityRationaleLevel2 = projectProjectInformation.CriticalityRationaleLevel2,
                Rollover = projectProjectInformation.Rollover,
                AwardOfficeFurnitureContracts = projectProjectInformation.AwardOfficeFurnitureContracts,
                RequiredOrDiscretionary = projectProjectInformation.RequiredOrDiscretionary,
                TechnologyRoomMepCommissioningIST = projectProjectInformation.TechnologyRoomMepCommissioningIST,
                FacilityType = projectProjectInformation.FacilityType,
                LocationCode = projectProjectInformation.LocationCode,
                ProjectStartReceiveBusinessRequest = projectProjectInformation.ProjectStartReceiveBusinessRequest,
                HeadCount = projectProjectInformation.HeadCount,
                CurrentProjectPhase = projectProjectInformation.CurrentProjectPhase,
                HandoverToFacilities = projectProjectInformation.HandoverToFacilities,
                PercentComplete = projectProjectInformation.PercentComplete,
                CurrentLeaseExpiryDate = projectProjectInformation.CurrentLeaseExpiryDate,
                BauOrRe = projectProjectInformation.BauOrRe,
                Scope = projectProjectInformation.Scope,
                ProjectId = projectProjectInformation.ProjectId,
                LastUpdated = projectProjectInformation.LastUpdated
            };
        }
    }
}