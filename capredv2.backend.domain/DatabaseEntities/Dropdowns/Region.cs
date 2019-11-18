using capredv2.backend.domain.DomainEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DatabaseEntities.Dropdowns
{
    public class Region
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public static Region MapFromDomainEntity(RegionDTO region)
        {
            if (region == null) return null;

            return new Region()
            {
                Id = region.Id,
                Value = region.Value,
                Position = region.Position
            };
        }
    }
}
