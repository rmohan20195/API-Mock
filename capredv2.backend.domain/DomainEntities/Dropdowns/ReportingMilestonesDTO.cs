using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DomainEntities.Dropdowns
{
    public class ReportingMilestonesDTO
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public ReportingMilestonesDTO()
        {
            Id = Guid.NewGuid();
        }

        public static ReportingMilestonesDTO MapFromDatabaseEntity(ReportingMilestones reportingMilestones)
        {
            if (reportingMilestones == null) return null;

            return new ReportingMilestonesDTO()
            {
                Id = reportingMilestones.Id,
                Value = reportingMilestones.Value,
                Position = reportingMilestones.Position
            };
        }
    }
}
