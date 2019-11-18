using System.Runtime.Serialization;
using capredv2.backend.domain.ExtensionMethods;
using NUnit.Framework;

namespace capredv2.backend.domain.tests.ExtensionMethods
{
    [TestFixture]
    public class EnumExtensionMethodsTests
    {
        [Test]
        public void GetEnumMemberValue_ValidEnumMemberWithEnumMemberAttribute_ReturnTheValueForTheEnumMemberAttribute()
        {
            //Act
            var test = MyEnum.SomeEnum.GetEnumMemberValue();

            //Assert
            StringAssert.AreEqualIgnoringCase("Detailed Description", test);
        }

        [Test]
        public void GetEnumMemberValue_ValidEnumMemberWithoutEnumMemberAttribute_ReturnNull()
        {
            //Act
            var test = MyEnum.SomeOtherEnum.GetEnumMemberValue();

            //Assert
            Assert.IsNull(test);
        }

        private enum MyEnum
        {
            [EnumMember(Value = "Detailed Description")]
            SomeEnum,
            SomeOtherEnum
        }
    }
}
