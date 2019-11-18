using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DomainEntities.Dropdowns
{
    public class FacilityTypeDTO
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public FacilityTypeDTO()
        {
            Id = Guid.NewGuid();
        }

        public static FacilityTypeDTO MapFromDatabaseEntity(FacilityType facilityType)
        {
            if (facilityType == null) return null;

            return new FacilityTypeDTO()
            {
                Id = facilityType.Id,
                Value = facilityType.Value,
                Position = facilityType.Position
            };
        }
    }
}
