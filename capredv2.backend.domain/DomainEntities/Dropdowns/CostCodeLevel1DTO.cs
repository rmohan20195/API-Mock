using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DomainEntities.Dropdowns
{
    public class CostCodeLevel1DTO
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public CostCodeLevel1DTO()
        {
            Id = Guid.NewGuid();
        }

        public static CostCodeLevel1DTO MapFromDatabaseEntity(CostCodeLevel1 costCodeLevel1)
        {
            if (costCodeLevel1 == null) return null;

            return new CostCodeLevel1DTO()
            {
                Id = costCodeLevel1.Id,
                Value = costCodeLevel1.Value,
                Position = costCodeLevel1.Position
            };
        }
    }
}
