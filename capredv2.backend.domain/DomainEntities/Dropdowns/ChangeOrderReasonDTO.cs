using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DomainEntities.Dropdowns
{
    public class ChangeOrderReasonDTO
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public ChangeOrderReasonDTO()
        {
            Id = Guid.NewGuid();
        }

        public static ChangeOrderReasonDTO MapFromDatabaseEntity(ChangeOrderReason changeOrderReason)
        {
            if (changeOrderReason == null) return null;

            return new ChangeOrderReasonDTO()
            {
                Id = changeOrderReason.Id,
                Value = changeOrderReason.Value,
                Position = changeOrderReason.Position
            };
        }
    }
}
