using System;
using System.Collections.Generic;
using System.Linq;
using capredv2.backend.domain.DatabaseEntities.CoupaImporterJobDefinitions;

namespace capredv2.backend.domain.DomainEntities.CoupaImporter
{
    public class CoupaImporterJobDefinitionDTO
    {
        public CoupaImporterJobDefinitionDTO()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string FileName { get; set; }
        public DateTime TimeStamp { get; set; }
        public CoupaImporterStatus Status { get; set; }
        public string FileType { get; set; }

        public IEnumerable<CoupaImporterJobDefinitionDetailDTO> CoupaImporterJobDefinitionDetails { get; set; }

        public Guid ProjectId { get; set; }

        public static CoupaImporterJobDefinitionDTO MapFromDatabaseEntity(CoupaImporterJobDefinition databaseEntity)
        {
            if (databaseEntity == null) return null;

            return new CoupaImporterJobDefinitionDTO
            {
                Id = databaseEntity.Id,
                FileName = databaseEntity.FileName,
                TimeStamp = databaseEntity.TimeStamp,
                Status = (CoupaImporterStatus) databaseEntity.Status,
				ProjectId = databaseEntity.ProjectId,
                FileType = databaseEntity.FileType,

                CoupaImporterJobDefinitionDetails =
                    databaseEntity.CoupaImporterJobDefinitionDetails
                        ?.Select(CoupaImporterJobDefinitionDetailDTO.MapFromDatabaseEntity).ToList() ??
                    new List<CoupaImporterJobDefinitionDetailDTO>()

            };
        }
    }
}
