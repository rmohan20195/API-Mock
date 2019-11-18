using System;
using capredv2.backend.domain.DomainEntities.Projects;
using NUnit.Framework;

namespace capredv2.backend.domain.tests.DomainEntities.Projects
{
    [TestFixture]
    public class RequisitionDTOTests
    {
        //Arrange
        RequisitionDTO requisition = new RequisitionDTO
        {
            ProjectId = new Guid("b58b6a58-2064-4c71-9b3d-c8c4514159a9"),
            RequisitionNumber = "1001",
            RequisitionLineNumber = "1",
            CostCode ="",
            CreatedBy = "Adam Leo",
            CurrentApprover ="Matt Hardy",
            RequisitionHeaderId = Guid.NewGuid(),
            ProjectDescription = "ProjDesc",
            RequestedBy = "Simon Lee",
            ShipToAddressName = "Nevada",
            TargetLocationCode = "Street 5",
            OrderTotal = "50000",
            ReportingTotal = "60000",
            Account = "Account",
            Supplier = "Supplier",
            CreatedDate = "5/3/2019",
            Status = "Status",
            PurchaseOrderNumber = "1234",
            Item = "Item",
            Currency = "USD",
            Id = Guid.NewGuid()
        };

        [Test]
        public void MapToRequisitionHeaderDTO_ValidEntity_ReturnDTOEntity()
        {
            //Act
            var response = RequisitionDTO.MapToRequisitionHeaderDTO(requisition);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(requisition.Id, response.Id);
            Assert.AreEqual(requisition.Supplier, response.Supplier);
            Assert.AreEqual(requisition.RequisitionNumber, response.RequisitionNumber.ToString());
            Assert.AreEqual(requisition.Status, response.Status);

            DateTime.TryParse(requisition.CreatedDate, out DateTime createdDate);
            Assert.AreEqual(createdDate, response.CreatedDate);

            Assert.AreEqual(requisition.Currency, response.Currency);
            Assert.AreEqual(requisition.PurchaseOrderNumber, response.PurchaseOrderNumber.ToString());
            Assert.AreEqual(requisition.ProjectId, response.ProjectId);
        }

        [Test]
        public void MapToRequisitionHeaderDTO_NullContent_ReturnNull()
        {
            //Act
            var response = RequisitionDTO.MapToRequisitionHeaderDTO(null);

            //Assert
            Assert.IsNull(response);
        }

        [Test]
        public void MapToRequisitionLineItemDTO_ValidEntity_ReturnDTOEntity()
        {
            //Act
            var response = RequisitionDTO.MapToRequisitionLineItemDTO(requisition);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(requisition.Id, response.Id);
            Assert.AreEqual(requisition.RequisitionLineNumber, response.RequisitionLineNumber.ToString());
            Assert.AreEqual(requisition.OrderTotal, response.OrderTotal.ToString());
            Assert.AreEqual(requisition.ReportingTotal, response.ReportingTotal.ToString());
            Assert.AreEqual(requisition.Item, response.Item);
            Assert.AreEqual(requisition.Account, response.Account);
            Assert.AreEqual(requisition.CostCode, response.CostCode);
            Assert.AreEqual(requisition.ProjectDescription, response.ProjectDescription);
            Assert.AreEqual(requisition.TargetLocationCode, response.TargetLocationCode);
            Assert.AreEqual(requisition.ShipToAddressName, response.ShipToAddressName);
            Assert.AreEqual(requisition.RequestedBy, response.RequestedBy);
            Assert.AreEqual(requisition.CurrentApprover, response.CurrentApprover);
            Assert.AreEqual(requisition.CreatedBy, response.CreatedBy);
            Assert.AreEqual(requisition.RequisitionHeaderId, response.RequisitionHeaderId);
        }

        [Test]
        public void MapToRequisitionLineItemDTO_NullContent_ReturnNull()
        {
            //Act
            var response = RequisitionDTO.MapToRequisitionLineItemDTO(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
