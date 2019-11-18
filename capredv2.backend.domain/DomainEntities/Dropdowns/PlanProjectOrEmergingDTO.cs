using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DomainEntities.Dropdowns
{
    public class PlanProjectOrEmergingDTO
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public PlanProjectOrEmergingDTO()
        {
            Id = Guid.NewGuid();
        }

        public static PlanProjectOrEmergingDTO MapFromDatabaseEntity(PlanProjectOrEmerging planProjectOrEmerging)
        {
            if (planProjectOrEmerging == null) return null;

            return new PlanProjectOrEmergingDTO()
            {
                Id = planProjectOrEmerging.Id,
                Value = planProjectOrEmerging.Value,
                Position = planProjectOrEmerging.Position
            };
        }
    }
}
