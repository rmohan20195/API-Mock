using capredv2.backend.domain.DatabaseEntities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace capredv2.backend.domain.DomainEntities.Projects
{
    public class RequisitionHeaderDTO
    {
        public RequisitionHeaderDTO()
        {
            Id = Guid.NewGuid();
            PurchaseOrderNumber = string.IsNullOrEmpty(this.PurchaseOrderNumber.ToString()) ? 0 : this.PurchaseOrderNumber;
        }
        public Guid Id { get; set; }
        public string Supplier { get; set; }
        public int? RequisitionNumber { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Currency { get; set; }
        public int? PurchaseOrderNumber { get; set; }

        public Guid ProjectId { get; set; }
        public IEnumerable<RequisitionLineItemDTO> RequisitionLineItems { get; set; }

        public static RequisitionHeaderDTO MapFromDatabaseEntity(RequisitionHeader requisitionHeader)
        {
            if (requisitionHeader == null) return null;

            return new RequisitionHeaderDTO
            {
                Id = requisitionHeader.Id,
                Supplier = requisitionHeader.Supplier,
                RequisitionNumber = requisitionHeader.RequisitionNumber,
                Status = requisitionHeader.Status,
                CreatedDate = requisitionHeader.CreatedDate,
                Currency = requisitionHeader.Currency,
                PurchaseOrderNumber = requisitionHeader.PurchaseOrderNumber,
                ProjectId = requisitionHeader.ProjectId,

                RequisitionLineItems = requisitionHeader.RequisitionLineItems?.Select(RequisitionLineItemDTO.MapFromDatabaseEntity).ToList() ??
                                 new List<RequisitionLineItemDTO>()
            };
        }
    }
}
