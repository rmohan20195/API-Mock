using capredv2.backend.domain.DomainEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DatabaseEntities.Dropdowns
{
    public class RealEstateOrBau
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public static RealEstateOrBau MapFromDomainEntity(RealEstateOrBauDTO realEstateOrBau)
        {
            if (realEstateOrBau == null) return null;

            return new RealEstateOrBau()
            {
                Id = realEstateOrBau.Id,
                Value = realEstateOrBau.Value,
                Position = realEstateOrBau.Position
            };
        }
    }
}
