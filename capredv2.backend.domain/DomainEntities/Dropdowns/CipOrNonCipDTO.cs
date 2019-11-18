using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DomainEntities.Dropdowns
{
    public class CipOrNonCipDTO
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public CipOrNonCipDTO()
        {
            Id = Guid.NewGuid();
        }

        public static CipOrNonCipDTO MapFromDatabaseEntity(CipOrNonCip cipOrNonCip)
        {
            if (cipOrNonCip == null) return null;

            return new CipOrNonCipDTO()
            {
                Id = cipOrNonCip.Id,
                Value = cipOrNonCip.Value,
                Position = cipOrNonCip.Position
            };
        }
    }
}
