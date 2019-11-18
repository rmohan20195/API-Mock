using capredv2.backend.domain.DatabaseEntities.Projects;
using LINQtoCSV;
using System;
using System.Collections.Generic;

namespace capredv2.backend.domain.DomainEntities.Projects
{
    public class InvoiceHeaderDTO
    {
        public InvoiceHeaderDTO()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [CsvColumn(Name = "Invoice #")]
        public string InvoiceNumber { get; set; }

        public string Supplier { get; set; }

        [CsvColumn(Name = "Invoice Date")]
        public DateTime? InvoiceDate { get; set; }

        [CsvColumn(Name = "Header status")]
        public string Status { get; set; }

        public string Currency { get; set; }

        [CsvColumn(Name = "Accounting Total Currency")]
        public string AccountingTotalCurrency { get; set; }

        public string Billing { get; set; }

        public Guid ProjectId { get; set; }

        public IEnumerable<InvoiceLineItemDTO> InvoiceLineItems { get; set; }


        public static InvoiceHeaderDTO MapFromDomainEntity(InvoiceHeader projectInvoiceHeader)
        {
            if (projectInvoiceHeader == null) return null;

            return new InvoiceHeaderDTO
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
