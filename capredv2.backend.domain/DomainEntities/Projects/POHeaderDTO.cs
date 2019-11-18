using capredv2.backend.domain.DatabaseEntities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace capredv2.backend.domain.DomainEntities.Projects
{
    public class POHeaderDTO
    {
        public POHeaderDTO()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Supplier { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? OrderTotal { get; set; }
        public string Currency { get; set; }
        public string AccountingTotalCurrency { get; set; }

        public Guid ProjectId { get; set; }

        public IEnumerable<POLineItemDTO> POLineItems { get; set; }

        public static POHeaderDTO MapFromDatabaseEntity(POHeader projectPOHeader)
        {
            if (projectPOHeader == null) return null;

            return new POHeaderDTO
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

                POLineItems = projectPOHeader.POLineItems?.Select(POLineItemDTO.MapFromDatabaseEntity).ToList() ??
                                 new List<POLineItemDTO>(),
            };
        }
    }
}
