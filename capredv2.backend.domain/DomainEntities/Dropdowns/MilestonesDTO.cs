using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DomainEntities.Dropdowns
{
    public class MilestonesDTO
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public MilestonesDTO()
        {
            Id = Guid.NewGuid();
        }

        public static MilestonesDTO MapFromDatabaseEntity(Milestones milestones)
        {
            if (milestones == null) return null;

            return new MilestonesDTO()
            {
                Id = milestones.Id,
                Value = milestones.Value,
                Position = milestones.Position
            };
        }
    }
}
