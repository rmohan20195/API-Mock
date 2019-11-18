using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DomainEntities.Projects;
using NUnit.Framework;
using System;

namespace capredv2.backend.domain.tests.DomainEntities.Projects
{
    public class POLineItemDTOTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var pOLineItem = new POLineItem
            {
                Id = Guid.NewGuid(),
                Account = "6063-521-5412424-203050-SN-00000-000-000",
                AccountingTotal = 5608.64,
                Commodity = "Office Supplies (5410615 Office Supplies)",
                CostCode = "C1001 - Interior Construction - General",
                CreatedBy = "Doris Ma",
                FixedAsset = "",
                Item = "Mindshare Social Media SOW",
                LastUpdatedBy = "Ritu Vij",
                POHeaderId = Guid.NewGuid(),
                ProjectDescription = "",
                RequestedBy = "Andy Lim",
                ShipTo = "Andy Lim",
                TargetLocationCode = "400 Bellevue Parkway, Wilmington - DE2 (21)",
            };

            //Act
            var response = POLineItemDTO.MapFromDatabaseEntity(pOLineItem);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(pOLineItem.Id, response.Id);
            Assert.AreEqual(pOLineItem.Account, response.Account);
            Assert.AreEqual(pOLineItem.AccountingTotal, response.AccountingTotal);
            Assert.AreEqual(pOLineItem.Commodity, response.Commodity);
            Assert.AreEqual(pOLineItem.CostCode, response.CostCode);
            Assert.AreEqual(pOLineItem.CreatedBy, response.CreatedBy);
            Assert.AreEqual(pOLineItem.FixedAsset, response.FixedAsset);
            Assert.AreEqual(pOLineItem.Item, response.Item);
            Assert.AreEqual(pOLineItem.LastUpdatedBy, response.LastUpdatedBy);
            Assert.AreEqual(pOLineItem.POHeaderId, response.POHeaderId);
            Assert.AreEqual(pOLineItem.ProjectDescription, response.ProjectDescription);
            Assert.AreEqual(pOLineItem.RequestedBy, response.RequestedBy);
            Assert.AreEqual(pOLineItem.ShipTo, response.ShipTo);
            Assert.AreEqual(pOLineItem.TargetLocationCode, response.TargetLocationCode);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = POLineItemDTO.MapFromDatabaseEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}

