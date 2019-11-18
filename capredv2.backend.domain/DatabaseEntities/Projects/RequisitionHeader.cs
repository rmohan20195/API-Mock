using capredv2.backend.domain.DomainEntities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace capredv2.backend.domain.DatabaseEntities.Projects
{
    public class RequisitionHeader
    {
        public Guid Id { get; set; }
        public string Supplier { get; set; }
        public int? RequisitionNumber { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Currency { get; set; }
        public int? PurchaseOrderNumber { get; set; }

        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public ICollection<RequisitionLineItem> RequisitionLineItems { get; set; }

        public static RequisitionHeader MapFromDomainEntity(RequisitionHeaderDTO requisitionHeader)
        {
            if (requisitionHeader == null) return null;

            return new RequisitionHeader
            {
                Id = requisitionHeader.Id,
                Supplier = requisitionHeader.Supplier,
                RequisitionNumber = requisitionHeader.RequisitionNumber,
                Status = requisitionHeader.Status,
                CreatedDate = requisitionHeader.CreatedDate,
                Currency = requisitionHeader.Currency,
                PurchaseOrderNumber= requisitionHeader.PurchaseOrderNumber,
                ProjectId = requisitionHeader.ProjectId,

                RequisitionLineItems = requisitionHeader.RequisitionLineItems?.Select(RequisitionLineItem.MapFromDomainEntity).ToList() ??
                                 new List<RequisitionLineItem>()
            };
        }
    }
}
