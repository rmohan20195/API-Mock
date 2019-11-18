using System;
using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DomainEntities.Projects;
using NUnit.Framework;

namespace capredv2.backend.domain.tests.DomainEntities.Projects
{
    [TestFixture]
    public class InvoiceLineItemDTOTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var invoiceLineItem = new InvoiceLineItem
            {
                Id = new Guid("110a0a30-3097-471b-962b-1d690c2ea8c6"),
                InvoiceHeaderId = new Guid("b58b6a58-2064-4c71-9b3d-c8c4514159a9"),
                AccountingTotal = 1250.89,
                Commodity = "Office Supplies (5410615 Office Supplies)",
                CreatedBy = "STAPLES ADVANTAGE Invoicing",
                CurrentApprover = "Ada Aromando",
                LocalPaymentDate = new DateTime(2019,5,3),
                Paid = "TRUE",
                PaymentNotes= "Paid in full",
                POLineTotal= 19500,
                PONumber= 4959,
                POShipToCity= "Frankfurt",
                POShipToCountry= "Germany",
                POShipToName= "New York - 55 East 52nd Street (PAZ)",
                ProjectDescription= "24135 - EFIV - Project Blade",
                ReqLineNumber = 19500,
                ReqLineTotal = 4,
                ReqNumber= "380",
                RequestedBy= "Marion Faerber",
                TargetLocationCode= "1 Lafayette Place, 2nd Floor, Greenwich - GW1 (MR)",
                Total= 103444.22,
                TotalTax = 0,
                WorkflowCode = ". Investments"
            };

            //Act
            var response = InvoiceLineItemDTO.MapFromDomainEntity(invoiceLineItem);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(invoiceLineItem.Id, response.Id);
            Assert.AreEqual(invoiceLineItem.InvoiceHeaderId, response.InvoiceHeaderId);
            Assert.AreEqual(invoiceLineItem.AccountingTotal, response.AccountingTotal);
            Assert.AreEqual(invoiceLineItem.Commodity, response.Commodity);
            Assert.AreEqual(invoiceLineItem.CreatedBy, response.CreatedBy);
            Assert.AreEqual(invoiceLineItem.CurrentApprover, response.CurrentApprover);
            Assert.AreEqual(invoiceLineItem.LocalPaymentDate, response.LocalPaymentDate);
            Assert.AreEqual(invoiceLineItem.Paid, response.Paid);
            Assert.AreEqual(invoiceLineItem.PaymentNotes, response.PaymentNotes);
            Assert.AreEqual(invoiceLineItem.POLineTotal, response.POLineTotal);
            Assert.AreEqual(invoiceLineItem.PONumber, response.PONumber);
            Assert.AreEqual(invoiceLineItem.POShipToCity, response.POShipToCity);
            Assert.AreEqual(invoiceLineItem.POShipToCountry, response.POShipToCountry);
            Assert.AreEqual(invoiceLineItem.POShipToName, response.POShipToName);
            Assert.AreEqual(invoiceLineItem.ProjectDescription, response.ProjectDescription);
            Assert.AreEqual(invoiceLineItem.ReqLineNumber, response.ReqLineNumber);
            Assert.AreEqual(invoiceLineItem.ReqLineTotal, response.ReqLineTotal);
            Assert.AreEqual(invoiceLineItem.ReqNumber, response.ReqNumber);
            Assert.AreEqual(invoiceLineItem.RequestedBy, response.RequestedBy);
            Assert.AreEqual(invoiceLineItem.TargetLocationCode, response.TargetLocationCode);
            Assert.AreEqual(invoiceLineItem.Total, response.Total);
            Assert.AreEqual(invoiceLineItem.TotalTax, response.TotalTax);
            Assert.AreEqual(invoiceLineItem.WorkflowCode, response.WorkflowCode);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = InvoiceLineItemDTO.MapFromDomainEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
