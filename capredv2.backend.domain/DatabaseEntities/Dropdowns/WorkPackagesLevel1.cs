using capredv2.backend.domain.DomainEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DatabaseEntities.Dropdowns
{
    public class WorkPackagesLevel1
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public static WorkPackagesLevel1 MapFromDomainEntity(WorkPackagesLevel1DTO workPackagesLevel1)
        {
            if (workPackagesLevel1 == null) return null;

            return new WorkPackagesLevel1()
            {
                Id = workPackagesLevel1.Id,
                Value = workPackagesLevel1.Value,
                Position = workPackagesLevel1.Position
            };
        }
    }
}
