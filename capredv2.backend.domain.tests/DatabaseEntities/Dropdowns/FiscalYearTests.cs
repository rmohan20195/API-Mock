using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DatabaseEntities.Dropdowns
{
    [TestFixture]
    public class FiscalYearTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var fiscalYear = new FiscalYearDTO()
            {
                Id = Guid.NewGuid(),
                Value = "2016",
                Position = 0
            };
            var response = FiscalYear.MapFromDomainEntity(fiscalYear);

            Assert.IsNotNull(response);
            Assert.AreEqual(fiscalYear.Id, response.Id);
            Assert.AreEqual(fiscalYear.Value, response.Value);
            Assert.AreEqual(fiscalYear.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = FiscalYear.MapFromDomainEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
