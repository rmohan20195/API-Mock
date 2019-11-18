using System;
using capredv2.backend.domain.DatabaseEntities.CoupaImporterJobDefinitions;

namespace capredv2.backend.domain.DomainEntities.CoupaImporter
{
    public class CoupaImporterJobDefinitionDetailDTO
    {
        public CoupaImporterJobDefinitionDetailDTO()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string RawContent { get; set; }
        public bool? IsSuccessful { get; set; }
        public string ErrorDescription { get; set; }
        public bool IsProcessed { get; set; }
        public int LineNumber { get; set; }

        public Guid CsvInviteJobDefinitionId { get; set; }

        public static CoupaImporterJobDefinitionDetailDTO MapFromDatabaseEntity(CoupaImporterJobDefinitionDetail databaseEntity)
        {
            return new CoupaImporterJobDefinitionDetailDTO
            {
                Id = databaseEntity.Id,
                CsvInviteJobDefinitionId = databaseEntity.CsvInviteJobDefinitionId,
                ErrorDescription = databaseEntity.ErrorDescription,
                IsProcessed = databaseEntity.IsProcessed,
                IsSuccessful = databaseEntity.IsSuccessful,
                LineNumber = databaseEntity.LineNumber,
                RawContent = databaseEntity.RawContent
            };
        }
    }
}