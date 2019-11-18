using capredv2.backend.domain.DomainEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DatabaseEntities.Dropdowns
{
    public class CipOrNonCip
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public static CipOrNonCip MapFromDomainEntity(CipOrNonCipDTO cipOrNonCip)
        {
            if (cipOrNonCip == null) return null;

            return new CipOrNonCip()
            {
                Id = cipOrNonCip.Id,
                Value = cipOrNonCip.Value,
                Position = cipOrNonCip.Position
            };
        }
    }
}
