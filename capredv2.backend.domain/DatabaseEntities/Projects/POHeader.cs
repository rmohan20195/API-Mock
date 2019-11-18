using capredv2.backend.domain.DomainEntities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace capredv2.backend.domain.DatabaseEntities.Projects
{
    public class POHeader
    {
        public Guid Id { get; set; }
        public string Supplier { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? OrderTotal { get; set; }
        public string Currency { get; set; }
        public string AccountingTotalCurrency { get; set; }

        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public ICollection<POLineItem> POLineItems { get; set; }

        public static POHeader MapFromDomainEntity(POHeaderDTO projectPOHeader)
        {
            if (projectPOHeader == null) return null;

            return new POHeader
            {
                Id = projectPOHeader.Id,
                Supplier = projectPOHeader.Supplier,
                PurchaseOrderNumber = projectPOHeader.PurchaseOrderNumber,
                ShippingAddress = projectPOHeader.ShippingAddress,
                OrderDate = projectPOHeader.OrderDate,
                OrderTotal = projectPOHeader.OrderTotal,
                Currency = projectPOHeader.Currency,
                AccountingTotalCurrency = projectPOHeader.AccountingTotalCurrency,

                ProjectId = projectPOHeader.ProjectId,

                POLineItems = projectPOHeader.POLineItems?.Select(POLineItem.MapFromDomainEntity).ToList() ??
                                 new List<POLineItem>(),
            };
        }
    }
}
