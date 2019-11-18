using capredv2.backend.domain.DomainEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DatabaseEntities.Dropdowns
{
    public class Milestones
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public static Milestones MapFromDomainEntity(MilestonesDTO milestones)
        {
            if (milestones == null) return null;

            return new Milestones()
            {
                Id = milestones.Id,
                Value = milestones.Value,
                Position = milestones.Position
            };
        }
    }
}
