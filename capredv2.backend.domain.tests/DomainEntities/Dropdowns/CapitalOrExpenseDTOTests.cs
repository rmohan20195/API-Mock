using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DomainEntities.Dropdowns
{
    [TestFixture]
    public class CapitalOrExpenseDTOTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var capitalOrExpense = new CapitalOrExpense()
            {
                Id = Guid.NewGuid(),
                Value = "Capital",
                Position = 0
            };
            var response = CapitalOrExpenseDTO.MapFromDatabaseEntity(capitalOrExpense);

            Assert.IsNotNull(response);
            Assert.AreEqual(capitalOrExpense.Id, response.Id);
            Assert.AreEqual(capitalOrExpense.Value, response.Value);
            Assert.AreEqual(capitalOrExpense.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = CapitalOrExpenseDTO.MapFromDatabaseEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
