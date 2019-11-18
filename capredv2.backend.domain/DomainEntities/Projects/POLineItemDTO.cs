using capredv2.backend.domain.DatabaseEntities.Projects;
using System;

namespace capredv2.backend.domain.DomainEntities.Projects
{
    public class POLineItemDTO
    {
        public POLineItemDTO()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Item { get; set; }
        public double? AccountingTotal { get; set; }
        public string ProjectDescription { get; set; }
        public string Commodity { get; set; }
        public string Account { get; set; }
        public string CostCode { get; set; }
        public string FixedAsset { get; set; }
        public string TargetLocationCode { get; set; }
        public string ShipTo { get; set; }
        public string RequestedBy { get; set; }
        public string CreatedBy { get; set; }
        public string LastUpdatedBy { get; set; }

        public Guid POHeaderId { get; set; }


        public static POLineItemDTO MapFromDatabaseEntity(POLineItem projectPOLineItem)
        {
            if (projectPOLineItem == null) return null;

            return new POLineItemDTO
            {
                Id = projectPOLineItem.Id,
                Item = projectPOLineItem.Item,
                AccountingTotal = projectPOLineItem.AccountingTotal,
                ProjectDescription = projectPOLineItem.ProjectDescription,
                Commodity = projectPOLineItem.Commodity,
                Account = projectPOLineItem.Account,
                CostCode = projectPOLineItem.CostCode,
                FixedAsset = projectPOLineItem.FixedAsset,
                TargetLocationCode = projectPOLineItem.TargetLocationCode,
                ShipTo = projectPOLineItem.ShipTo,
                RequestedBy = projectPOLineItem.RequestedBy,
                CreatedBy = projectPOLineItem.CreatedBy,
                LastUpdatedBy = projectPOLineItem.LastUpdatedBy,

                POHeaderId = projectPOLineItem.POHeaderId
            };
        }
    }
}
