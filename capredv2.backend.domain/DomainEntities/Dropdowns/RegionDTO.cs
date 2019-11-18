using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DomainEntities.Dropdowns
{
    public class RegionDTO
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public RegionDTO()
        {
            Id = Guid.NewGuid();
        }

        public static RegionDTO MapFromDatabaseEntity(Region region)
        {
            if (region == null) return null;

            return new RegionDTO()
            {
                Id = region.Id,
                Value = region.Value,
                Position = region.Position
            };
        }
    }
}
