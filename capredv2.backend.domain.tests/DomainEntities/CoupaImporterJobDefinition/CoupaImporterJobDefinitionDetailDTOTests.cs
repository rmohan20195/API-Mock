using System;
using capredv2.backend.domain.DatabaseEntities.CoupaImporterJobDefinitions;
using capredv2.backend.domain.DomainEntities.CoupaImporter;
using NUnit.Framework;

namespace capredv2.backend.domain.tests.DomainEntities.CoupaImporterJobDefinition
{
    [TestFixture]
    public class CoupaImporterJobDefinitionDetailDTOTests
    {
        [Test]
        public void CreateNewEntity_EmptyEntity_CreateEmptyEntityWithValidId()
        {
            //Act
            var result = new CoupaImporterJobDefinitionDetailDTO();

            //Assert
            Assert.IsNotNull(result.Id);
            Assert.AreNotEqual(new Guid(), result.Id);
        }

        [Test]
        public void MapFromDatabaseEntity_ValidEntity_ReturnDatabaseEntity()
        {
            //Arrange
            var domainEntity = new CoupaImporterJobDefinitionDetail
            {
                Id = new Guid("9ac05079-a2c4-4402-b64f-35e980a4be88"),
                CsvInviteJobDefinitionId = new Guid("dd797697-6e95-4175-9637-f84ee3002088"),
                ErrorDescription = "Error",
                IsSuccessful = false,
                RawContent = "Raw Content",
                LineNumber = 1,
                IsProcessed = true
            };

            //Act
            var result = CoupaImporterJobDefinitionDetailDTO.MapFromDatabaseEntity(domainEntity);

            //Assert
            Assert.AreEqual(domainEntity.Id, result.Id);
            Assert.AreEqual(domainEntity.CsvInviteJobDefinitionId, result.CsvInviteJobDefinitionId);
            Assert.AreEqual(domainEntity.ErrorDescription, result.ErrorDescription);
            Assert.AreEqual(domainEntity.IsProcessed, result.IsProcessed);
            Assert.AreEqual(domainEntity.IsSuccessful, result.IsSuccessful);
            Assert.AreEqual(domainEntity.RawContent, result.RawContent);
            Assert.AreEqual(domainEntity.LineNumber, result.LineNumber);
        }
    }
}
