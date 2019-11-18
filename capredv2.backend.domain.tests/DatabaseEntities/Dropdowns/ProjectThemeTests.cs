using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DatabaseEntities.Dropdowns
{
    [TestFixture]
    public class ProjectThemeTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var projectTheme = new ProjectThemeDTO()
            {
                Id = Guid.NewGuid(),
                Value = "BAU",
                Position = 0
            };
            var response = ProjectTheme.MapFromDomainEntity(projectTheme);

            Assert.IsNotNull(response);
            Assert.AreEqual(projectTheme.Id, response.Id);
            Assert.AreEqual(projectTheme.Value, response.Value);
            Assert.AreEqual(projectTheme.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = ProjectTheme.MapFromDomainEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
