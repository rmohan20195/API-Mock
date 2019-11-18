sing System;
using capredv2.backend.domain.DomainEntities.Projects;

namespace capredv2.backend.domain.DatabaseEntities.Projects
{
    public class PurchaseOrder
    {
        public Guid Id { get; set; }
        public int PurchaseOrderNumber { get; set; }
        public double OrderTotal { get; set; }
        public double AccountingTotal { get; set; }
        public string Account { get; set; }
        public string Supplier { get; set; }
        public DateTime OrderDate { get; set; }
        public string Item { get; set; }
        public string AccountingTotalCurrency { get; set; }
        public string Currency { get; set; }

        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public static PurchaseOrder MapFromDomainEntity(PurchaseOrderDTO projectPurchaseOrder)
        {
            if (projectPurchaseOrder == null) return null;

            return new PurchaseOrder
            {
                Id = Guid.NewGuid(),
                ProjectId = projectPurchaseOrder.ProjectId,
                OrderTotal = projectPurchaseOrder.OrderTotal,
                PurchaseOrderNumber = projectPurchaseOrder.PurchaseOrderNumber,
                Account = projectPurchaseOrder.Account,
                Currency = projectPurchaseOrder.Currency,
                Supplier = projectPurchaseOrder.Supplier,
                OrderDate = projectPurchaseOrder.OrderDate,
                AccountingTotalCurrency = projectPurchaseOrder.AccountingTotalCurrency,
                Item = projectPurchaseOrder.Item,
                AccountingTotal = projectPurchaseOrder.AccountingTotal
            };
        }
    }
}