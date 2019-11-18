using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DomainEntities.Dropdowns
{
    [TestFixture]
    public class ProjectThemeDTOTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var projectTheme = new ProjectTheme()
            {
                Id = Guid.NewGuid(),
                Value = "BAU",
                Position = 0
            };
            var response = ProjectThemeDTO.MapFromDatabaseEntity(projectTheme);

            Assert.IsNotNull(response);
            Assert.AreEqual(projectTheme.Id, response.Id);
            Assert.AreEqual(projectTheme.Value, response.Value);
            Assert.AreEqual(projectTheme.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = ProjectThemeDTO.MapFromDatabaseEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
