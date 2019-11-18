using capredv2.backend.domain.DomainEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DatabaseEntities.Dropdowns
{
    public class ReportingMilestones
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public static ReportingMilestones MapFromDomainEntity(ReportingMilestonesDTO reportingMilestones)
        {
            if (reportingMilestones == null) return null;

            return new ReportingMilestones()
            {
                Id = reportingMilestones.Id,
                Value = reportingMilestones.Value,
                Position = reportingMilestones.Position
            };
        }
    }
}
