using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DatabaseEntities.Dropdowns
{
    [TestFixture]
    public class CapitalOrExpenseTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var capitalOrExpense = new CapitalOrExpenseDTO()
            {
                Id = Guid.NewGuid(),
                Value = "Capital",
                Position = 0
            };
            var response = CapitalOrExpense.MapFromDomainEntity(capitalOrExpense);

            Assert.IsNotNull(response);
            Assert.AreEqual(capitalOrExpense.Id, response.Id);
            Assert.AreEqual(capitalOrExpense.Value, response.Value);
            Assert.AreEqual(capitalOrExpense.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = CapitalOrExpense.MapFromDomainEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
