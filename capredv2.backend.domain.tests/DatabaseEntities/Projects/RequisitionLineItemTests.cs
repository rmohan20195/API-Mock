using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DomainEntities.Projects;
using NUnit.Framework;
using System;

namespace capredv2.backend.domain.tests.DatabaseEntities.Projects
{
    public class RequisitionLineItemTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var requisition = new RequisitionLineItemDTO
            {
                Account = "802-001-5410615-421133-DR-00000-000-000",
                CostCode = "",
                CreatedBy = "Kate Machala",
                CurrentApprover = "Anthony Diaz-Matos",
                Item = "Puppet Open Source Assessment",
                OrderTotal = 6336.85,
                ProjectDescription = "PRJ8962 - Windows 10 Program - Phase 1",
                ReportingTotal = 6336.85,
                RequestedBy = "Diana Thorgerson",
                RequisitionLineNumber = 14937,
                RequisitionHeaderId = Guid.NewGuid(),
                ShipToAddressName = "55 East 52nd Street, New York, NY 10055, United States",
                TargetLocationCode = "Sao Paulo, Brazil - New Location - SP1 (JS)",
                Id = Guid.NewGuid()
            };

            //Act
            var response = RequisitionLineItem.MapFromDomainEntity(requisition);

            //Assert
            Assert.IsNotNull(response);          
            Assert.AreEqual(requisition.Item, response.Item);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = RequisitionLineItem.MapFromDomainEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
