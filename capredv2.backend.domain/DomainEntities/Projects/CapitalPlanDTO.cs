using System;
using capredv2.backend.domain.DatabaseEntities.Projects;

namespace capredv2.backend.domain.DomainEntities.Projects
{
    public class CapitalPlanDTO
    {
        public CapitalPlanDTO()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public int Priority { get; set; }
        public bool Rollover { get; set; }
        public int RolloverCategory { get; set; }
        public bool PartOfPBASubmission { get; set; }
        public int BusinessPriority { get; set; }
        public string Theme { get; set; }
        public string BusinessDriver { get; set; }
        public string Group { get; set; }
        public string LeaseExpiry { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RiskToBusinessByNotDoingIt { get; set; }
        public bool BusinessRequirementsDone { get; set; }
        public string Comments { get; set; }

        public static CapitalPlanDTO MapFromDatabaseEntity(CapitalPlan projectCapitalPlan)
        {
            if (projectCapitalPlan == null) return null;

            return new CapitalPlanDTO
            {
				Id = projectCapitalPlan.Id, //TODO: create Unit Test to cover this line
                Rollover = projectCapitalPlan.Rollover,
                BusinessDriver = projectCapitalPlan.BusinessDriver,
                ProjectId = projectCapitalPlan.ProjectId,
                LeaseExpiry = projectCapitalPlan.LeaseExpiry,
                StartDate = projectCapitalPlan.StartDate,
                Group = projectCapitalPlan.Group,
                PartOfPBASubmission = projectCapitalPlan.PartOfPBASubmission,
                Priority = projectCapitalPlan.Priority,
                EndDate = projectCapitalPlan.EndDate,
                BusinessPriority = projectCapitalPlan.BusinessPriority,
                RiskToBusinessByNotDoingIt = projectCapitalPlan.RiskToBusinessByNotDoingIt,
                RolloverCategory = projectCapitalPlan.RolloverCategory,
                BusinessRequirementsDone = projectCapitalPlan.BusinessRequirementsDone,
                Theme = projectCapitalPlan.Theme,
                Comments = projectCapitalPlan.Comments
            };
        }
    }
}