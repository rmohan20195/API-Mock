using capredv2.backend.domain.DomainEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DatabaseEntities.Dropdowns
{
    public class FacilityType
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public static FacilityType MapFromDomainEntity(FacilityTypeDTO facilityType)
        {
            if (facilityType == null) return null;

            return new FacilityType()
            {
                Id = facilityType.Id,
                Value = facilityType.Value,
                Position = facilityType.Position
            };
        }
    }
}
