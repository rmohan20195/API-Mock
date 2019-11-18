using capredv2.backend.domain.DomainEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DatabaseEntities.Dropdowns
{
    public class CostCodeLevel2
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public static CostCodeLevel2 MapFromDomainEntity(CostCodeLevel2DTO costCodeLevel2)
        {
            if (costCodeLevel2 == null) return null;

            return new CostCodeLevel2()
            {
                Id = costCodeLevel2.Id,
                Value = costCodeLevel2.Value,
                Position = costCodeLevel2.Position
            };
        }
    }
}
