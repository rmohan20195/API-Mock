using capredv2.backend.domain.DomainEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DatabaseEntities.Dropdowns
{
    public class CostCodeLevel1
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public static CostCodeLevel1 MapFromDomainEntity(CostCodeLevel1DTO costCodeLevel1)
        {
            if (costCodeLevel1 == null) return null;

            return new CostCodeLevel1()
            {
                Id = costCodeLevel1.Id,
                Value = costCodeLevel1.Value,
                Position = costCodeLevel1.Position
            };
        }
    }
}
