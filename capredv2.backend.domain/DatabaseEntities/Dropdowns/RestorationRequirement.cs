using capredv2.backend.domain.DomainEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DatabaseEntities.Dropdowns
{
    public class RestorationRequirement
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public static RestorationRequirement MapFromDomainEntity(RestorationRequirementDTO restorationRequirement)
        {
            if (restorationRequirement == null) return null;

            return new RestorationRequirement()
            {
                Id = restorationRequirement.Id,
                Value = restorationRequirement.Value,
                Position = restorationRequirement.Position
            };
        }
    }
}
