using System;
using System.Collections.Generic;
using System.Linq;
using capredv2.backend.domain.DatabaseEntities.CoupaImporterJobDefinitions;
using capredv2.backend.domain.DataContexts.CapRedV2SQLContext;
using capredv2.backend.domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace capredv2.backend.domain.Repositories
{
    public class CoupaImporterRepository : ICoupaImporterRepository
    {
        private readonly CapRedV2Context _context;

        public CoupaImporterRepository(CapRedV2Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public CoupaImporterJobDefinition Add(CoupaImporterJobDefinition jobDefinition)
        {
            return _context.CoupaImporterJodDefinitions.Add(jobDefinition).Entity;
        }

        public CoupaImporterJobDefinition Get(Guid jobDefinitionId)
        {
            return _context.CoupaImporterJodDefinitions
                .Include(i => i.CoupaImporterJobDefinitionDetails)
                .FirstOrDefault(j => j.Id == jobDefinitionId);
        }

        public void UpdateJobDefinitionDetail(Guid jobDefinitionId, CoupaImporterJobDefinitionDetail coupaImporterJobDefinitionDetail)
        {
            var entityInContext = _context.CoupaImporterJobDefinitionDetails.First(c => c.Id == jobDefinitionId);

            if (entityInContext == null)
                return;

            _context.Entry(entityInContext).CurrentValues.SetValues(coupaImporterJobDefinitionDetail);
            _context.Entry(entityInContext).State = EntityState.Modified;
        }

        public void UpdateAllJobDefinitionDetail(Guid jobDefinitionId, IEnumerable<CoupaImporterJobDefinitionDetail> coupaImporterJobDefinitions)
        {
            var entityInContext = _context.CoupaImporterJobDefinitionDetails.Where(c => c.CsvInviteJobDefinitionId == jobDefinitionId).ToList();

	        entityInContext.ForEach(c =>
            {
                _context.Entry(c).CurrentValues.SetValues(coupaImporterJobDefinitions.First(x => x.Id == c.Id));
                _context.Entry(c).State = EntityState.Modified;
            });
        }

        public void Update(Guid jobDefinitionId, CoupaImporterJobDefinition coupaImporterJobDefinition)
        {
            var entityInContext = _context.CoupaImporterJodDefinitions.First(c => c.Id == jobDefinitionId);

            if (entityInContext == null)
                return;

            _context.Entry(entityInContext).CurrentValues.SetValues(coupaImporterJobDefinition);
            _context.Entry(entityInContext).State = EntityState.Modified;
        }


    }
}
