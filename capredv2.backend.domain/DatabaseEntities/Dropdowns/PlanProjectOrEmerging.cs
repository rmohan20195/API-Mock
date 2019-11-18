using capredv2.backend.domain.DomainEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DatabaseEntities.Dropdowns
{
    public class PlanProjectOrEmerging
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public static PlanProjectOrEmerging MapFromDomainEntity(PlanProjectOrEmergingDTO planProjectOrEmerging)
        {
            if (planProjectOrEmerging == null) return null;

            return new PlanProjectOrEmerging()
            {
                Id = planProjectOrEmerging.Id,
                Value = planProjectOrEmerging.Value,
                Position = planProjectOrEmerging.Position
            };
        }
    }
}
