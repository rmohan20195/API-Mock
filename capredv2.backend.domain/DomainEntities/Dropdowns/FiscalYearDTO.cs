using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DomainEntities.Dropdowns
{
    public class FiscalYearDTO
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }
        public FiscalYearDTO()
        {
            Id = Guid.NewGuid();
        }

        public static FiscalYearDTO MapFromDatabaseEntity(FiscalYear fiscalYear)
        {
            if (fiscalYear == null) return null;

            return new FiscalYearDTO()
            {
                Id = fiscalYear.Id,
                Value = fiscalYear.Value,
                Position = fiscalYear.Position
            };
        }

    }
}
