using System;
using capredv2.backend.domain.DomainEntities.Projects;

namespace capredv2.backend.domain.DatabaseEntities.Projects
{
    public class Invoice
    {
	    public Guid Id { get; set; }
        public string InvoiceNumber { get; set; }
        public double Total { get; set; }
        public bool Paid { get; set; }
        public string Account { get; set; }
        public string Supplier { get; set; }
        public long? PurchaseOrderNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime ReceivedOrCreatedDate { get; set; }
        public string Status { get; set; }
        public DateTime? LocalPaymentDate { get; set; }

        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }

	    public static Invoice MapFromDomainEntity(InvoiceDTO projectInvoice)
        {
            if (projectInvoice == null) return null;

            return new Invoice
            {
				Id = projectInvoice.Id,
                ProjectId = projectInvoice.ProjectId,
                Status = projectInvoice.Status,
                PurchaseOrderNumber = projectInvoice.PurchaseOrderNumber,
                Account = projectInvoice.Account,
                Supplier = projectInvoice.Supplier,
                ReceivedOrCreatedDate = projectInvoice.ReceivedOrCreatedDate,
                InvoiceDate = projectInvoice.InvoiceDate,
                InvoiceNumber = projectInvoice.InvoiceNumber,
                LocalPaymentDate = projectInvoice.LocalPaymentDate,
                Paid = projectInvoice.Paid,
                Total = projectInvoice.Total
            };
        }
    }
}