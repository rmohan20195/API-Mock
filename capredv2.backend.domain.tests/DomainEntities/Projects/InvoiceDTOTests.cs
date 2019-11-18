using System;
using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DomainEntities.Projects;
using NUnit.Framework;

namespace capredv2.backend.domain.tests.DomainEntities.Projects
{
    [TestFixture]
    public class InvoiceDTOTests
    {
        [Test]
        public void MapFromDatabaseEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var invoice = new Invoice
            {
				Id = new Guid("110a0a30-3097-471b-962b-1d690c2ea8c6"),
                ProjectId = new Guid("b58b6a58-2064-4c71-9b3d-c8c4514159a9"),
                InvoiceNumber = "5555",
                Total = 50000D,
                Paid = true,
                Account = "Account",
                Supplier = "Supplier",
                PurchaseOrderNumber = 1234,
                InvoiceDate = new DateTime(2019, 08, 01),
                ReceivedOrCreatedDate = new DateTime(2019, 08, 08),
                Status = "Status",
                LocalPaymentDate = new DateTime(2019, 08, 10)
            };

            //Act
            var response = InvoiceDTO.MapFromDatabaseEntity(invoice);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(invoice.Id, response.Id);
            Assert.AreEqual(invoice.ProjectId, response.ProjectId);
	        Assert.AreEqual(invoice.InvoiceNumber, response.InvoiceNumber);
            Assert.AreEqual(invoice.Total, response.Total);
            Assert.AreEqual(invoice.Paid, response.Paid);
            Assert.AreEqual(invoice.Account, response.Account);
            Assert.AreEqual(invoice.Supplier, response.Supplier);
            Assert.AreEqual(invoice.PurchaseOrderNumber, response.PurchaseOrderNumber);
            Assert.AreEqual(invoice.InvoiceDate, response.InvoiceDate);
            Assert.AreEqual(invoice.ReceivedOrCreatedDate, response.ReceivedOrCreatedDate);
            Assert.AreEqual(invoice.Status, response.Status);
            Assert.AreEqual(invoice.LocalPaymentDate, response.LocalPaymentDate);
        }

        [Test]
        public void MapFromDatabaseEntity_NullContent_ReturnNull()
        {
            //Act
            var response = InvoiceDTO.MapFromDatabaseEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
