using System;
using capredv2.backend.domain.DomainEntities.CoupaImporter;
using NUnit.Framework;

namespace capredv2.backend.domain.tests.DomainEntities.CoupaImporterJobDefinition
{
    [TestFixture]
    public class CoupaImporterJobDefinitionDTOTests
    {
        [Test]
        public void CreateNewEntity_EmptyEntity_CreateEmptyEntityWithValidId()
        {
            //Act
            var result = new CoupaImporterJobDefinitionDTO();

            //Assert
            Assert.IsNotNull(result.Id);
            Assert.AreNotEqual(new Guid(), result.Id);
        }

        [Test]
        public void MapFromDatabaseEntity_ValidEntity_ReturnDomainEntity()
        {
            //Arrange
            var databaseEntity = new domain.DatabaseEntities.CoupaImporterJobDefinitions.CoupaImporterJobDefinition
            {
                Id = new Guid("45744a2e-3dc1-472f-9bb5-378a0a9eeda4"),
                FileName = "fileTest.csv",
                Status = (int) CoupaImporterStatus.Pending,
                TimeStamp = DateTime.UtcNow,
	            ProjectId = new Guid("4d75753e-618d-4067-9019-f91a64407bca")
			};

            //Act
            var result = CoupaImporterJobDefinitionDTO.MapFromDatabaseEntity(databaseEntity);

            //Assert
            Assert.AreEqual(databaseEntity.Id, result.Id);
            Assert.AreEqual(databaseEntity.ProjectId, result.ProjectId);
	        Assert.AreEqual(databaseEntity.FileName, result.FileName);
            Assert.AreEqual(databaseEntity.TimeStamp, result.TimeStamp);
            Assert.AreEqual(databaseEntity.Status, (int)result.Status);
        }
    }
}
