using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DomainEntities.Dropdowns
{
    public class CostCodeLevel2DTO
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public CostCodeLevel2DTO()
        {
            Id = Guid.NewGuid();
        }

        public static CostCodeLevel2DTO MapFromDatabaseEntity(CostCodeLevel2 costCodeLevel2)
        {
            if (costCodeLevel2 == null) return null;

            return new CostCodeLevel2DTO()
            {
                Id = costCodeLevel2.Id,
                Value = costCodeLevel2.Value,
                Position = costCodeLevel2.Position
            };
        }
    }
}
