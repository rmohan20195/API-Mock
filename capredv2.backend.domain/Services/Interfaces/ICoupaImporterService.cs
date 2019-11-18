using System;
using System.Collections.Generic;
using System.IO;
using capredv2.backend.domain.DomainEntities.CoupaImporter;
using capredv2.backend.domain.DomainEntities.Enums;

namespace capredv2.backend.domain.Services.Interfaces
{
    public interface ICoupaImporterService
    {
        CoupaImporterJobDefinitionDTO CreateInvoiceImportJobDefinition(Guid projectId, MemoryStream memoryStream, string fileName);
        CoupaImporterJobDefinitionDTO CreatePurchaseOrderImportJobDefinition(Guid projectId, MemoryStream memoryStream, string fileName);
        CoupaImporterJobDefinitionDTO CreateRequisitionImportJobDefinition(Guid projectId, MemoryStream memoryStream, string fileName);
        CoupaImporterJobDefinitionDTO ProcessInvoiceImportJob(Guid jobDefinitionId);
        CoupaImporterJobDefinitionDTO ProcessPurchaseOrderImportJob(Guid jobDefinitionId);
        CoupaImporterJobDefinitionDTO ProcessRequisitionImportJob(Guid jobDefinitionId);

        CoupaImporterJobDefinitionDTO SetCoupaImporterJobDefinitionDTO<T>(IEnumerable<T> dataList, Guid projectId, string fileName, FileType fileType) where T : new();
    }
}
