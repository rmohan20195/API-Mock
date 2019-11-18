using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DomainEntities.Dropdowns
{
    public class RestorationRequirementDTO
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public RestorationRequirementDTO()
        {
            Id = Guid.NewGuid();
        }

        public static RestorationRequirementDTO MapFromDatabaseEntity(RestorationRequirement restorationRequirement)
        {
            if (restorationRequirement == null) return null;

            return new RestorationRequirementDTO()
            {
                Id = restorationRequirement.Id,
                Value = restorationRequirement.Value,
                Position = restorationRequirement.Position
            };
        }
    }

}
