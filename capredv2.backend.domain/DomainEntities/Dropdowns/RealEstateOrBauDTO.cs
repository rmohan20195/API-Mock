using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DomainEntities.Dropdowns
{
    public class RealEstateOrBauDTO
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public RealEstateOrBauDTO()
        {
            Id = Guid.NewGuid();
        }

        public static RealEstateOrBauDTO MapFromDatabaseEntity(RealEstateOrBau realEstateOrBau)
        {
            if (realEstateOrBau == null) return null;

            return new RealEstateOrBauDTO()
            {
                Id = realEstateOrBau.Id,
                Value = realEstateOrBau.Value,
                Position = realEstateOrBau.Position
            };
        }
    }
}
