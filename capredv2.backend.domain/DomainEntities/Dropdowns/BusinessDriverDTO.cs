using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DomainEntities.Dropdowns
{
    public class BusinessDriverDTO
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public BusinessDriverDTO()
        {
            Id = Guid.NewGuid();
        }

        public static BusinessDriverDTO MapFromDatabaseEntity(BusinessDriver businessDriver)
        {
            if (businessDriver == null) return null;

            return new BusinessDriverDTO()
            {
                Id = businessDriver.Id,
                Value = businessDriver.Value,
                Position = businessDriver.Position
            };
        }
    }
}
