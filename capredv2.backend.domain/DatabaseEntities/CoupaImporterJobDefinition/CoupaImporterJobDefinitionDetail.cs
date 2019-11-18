using System;
using capredv2.backend.domain.DomainEntities.CoupaImporter;

namespace capredv2.backend.domain.DatabaseEntities.CoupaImporterJobDefinitions
{
    public class CoupaImporterJobDefinitionDetail
    {
        public Guid Id { get; set; }
        public string RawContent { get; set; }
        public bool? IsSuccessful { get; set; }
        public string ErrorDescription { get; set; }
        public bool IsProcessed { get; set; }
        public int LineNumber { get; set; }

        public Guid CsvInviteJobDefinitionId { get; set; }
        public virtual CoupaImporterJobDefinition CsvInviteJobDefinition { get; set; }

        public static CoupaImporterJobDefinitionDetail MapFromDomainEntity(CoupaImporterJobDefinitionDetailDTO domainEntity)
        {
            return new CoupaImporterJobDefinitionDetail
            {
                Id = domainEntity.Id,
                CsvInviteJobDefinitionId = domainEntity.CsvInviteJobDefinitionId,
                ErrorDescription = domainEntity.ErrorDescription,
                IsProcessed = domainEntity.IsProcessed,
                IsSuccessful = domainEntity.IsSuccessful,
                LineNumber = domainEntity.LineNumber,
                RawContent = domainEntity.RawContent
            };
        }
    }
}