using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DomainEntities.Dropdowns
{
    public class WorkPackagesLevel1DTO
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public WorkPackagesLevel1DTO()
        {
            Id = Guid.NewGuid();
        }

        public static WorkPackagesLevel1DTO MapFromDatabaseEntity(WorkPackagesLevel1 workPackagesLevel1)
        {
            if (workPackagesLevel1 == null) return null;

            return new WorkPackagesLevel1DTO()
            {
                Id = workPackagesLevel1.Id,
                Value = workPackagesLevel1.Value,
                Position = workPackagesLevel1.Position
            };
        }
    }
}
