using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DomainEntities.Dropdowns
{
    public class BusinessRiskDTO
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public BusinessRiskDTO()
        {
            Id = Guid.NewGuid();
        }

        public static BusinessRiskDTO MapFromDatabaseEntity(BusinessRisk businessRisk)
        {
            if (businessRisk == null) return null;

            return new BusinessRiskDTO()
            {
                Id = businessRisk.Id,
                Value = businessRisk.Value,
                Position = businessRisk.Position
            };
        }
    }
}
