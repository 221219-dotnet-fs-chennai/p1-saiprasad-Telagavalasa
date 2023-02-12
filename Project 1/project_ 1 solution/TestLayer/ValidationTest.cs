using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness_Logic;

namespace TestLayer
{
    public  class ValidationTest
    {
     
        [Test]
        [TestCase("Saiprasad@gmail.com", true)]
        [TestCase("Sai@gmacom", false)]
        [TestCase("saip4207@gmail.com",true)]
        [TestCase("saiprasad.com",false)]
        public void TestEmail(string email, bool expectedResult)
        {
            Assert.AreEqual(UserValidation.isValidEmail(email), expectedResult);
        }

        [Test]
        [TestCase("sai123", false)]
        [TestCase("venkatsai", false)]
        [TestCase("Saiprasad5123", true)]
        [TestCase("@ppu12",false)]
        public void TestPassword(string password, bool expectedResult)
        {
            Assert.AreEqual(UserValidation.isValidPassword(password), expectedResult);
        }

        [Test]
        [TestCase("9012811256", true)]
        [TestCase("923456789098", false)]
        [TestCase("8158552345678", false)]
        [TestCase("9030616105",true)]
        public void TestPhone(string phone, bool expectedResult)
        {
            Assert.AreEqual(UserValidation.isValidPhone(phone), expectedResult);
        }

        [Test]
        [TestCase("533124", true)]
        [TestCase("09876",false)]
        [TestCase("603103", true)]
        [TestCase("67890123",false)]
        public void TestZipcode(string zipcode, bool expectedResult)
        {
            Assert.AreEqual(UserValidation.isValidZipcode(zipcode), expectedResult);
        }




    }
}
