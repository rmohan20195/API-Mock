using capredv2.backend.domain.DomainEntities.Projects;
using System;
using System.Collections.Generic;

namespace capredv2.backend.domain.DatabaseEntities.Projects
{
    public class InvoiceHeader
    {
        public Guid Id { get; set; }
        public string InvoiceNumber { get; set; }
        public string Supplier { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string Status { get; set; }
        public string Currency { get; set; }
        public string AccountingTotalCurrency { get; set; }
        public string Billing { get; set; }

        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public ICollection<InvoiceLineItem> InvoiceLineItems { get; set; }

        public static InvoiceHeader MapFromDomainEntity(InvoiceHeaderDTO projectInvoiceHeader)
        {
            if (projectInvoiceHeader == null) return null;

            return new InvoiceHeader
            {
                Id = projectInvoiceHeader.Id,
                ProjectId = projectInvoiceHeader.ProjectId,
                Status = projectInvoiceHeader.Status,
                AccountingTotalCurrency = projectInvoiceHeader.AccountingTotalCurrency,
                Billing = projectInvoiceHeader.Billing,
                Currency = projectInvoiceHeader.Currency,
                InvoiceDate = projectInvoiceHeader.InvoiceDate,
                InvoiceNumber = projectInvoiceHeader.InvoiceNumber,
                Supplier = projectInvoiceHeader.Supplier
            };
        }
    }
}
