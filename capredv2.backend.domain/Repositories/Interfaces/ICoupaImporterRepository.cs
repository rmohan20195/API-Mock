using System;
using System.Collections.Generic;
using capredv2.backend.domain.DatabaseEntities.CoupaImporterJobDefinitions;

namespace capredv2.backend.domain.Repositories.Interfaces
{
    public interface ICoupaImporterRepository
    {
        CoupaImporterJobDefinition Add(CoupaImporterJobDefinition jobDefinition);
        CoupaImporterJobDefinition Get(Guid jobDefinitionId);
        void UpdateJobDefinitionDetail(Guid id, CoupaImporterJobDefinitionDetail coupaImporterJobDefinitionDetail);
        void UpdateAllJobDefinitionDetail(Guid id, IEnumerable<CoupaImporterJobDefinitionDetail> coupaImporterJobDefinitions);
        void Update(Guid jobDefinitionId, CoupaImporterJobDefinition coupaImporterJobDefinition);
    }
}
