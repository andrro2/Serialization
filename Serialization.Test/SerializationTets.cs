using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Serialization.Test
{
    [TestFixture]
    public class SerializationTets
    {
        private Person person;
        private DateTime birthDateTest;
        private string nameTest;


        [SetUp]
        public void Setup()
        {
            nameTest = "John";
            birthDateTest = new DateTime(1990, 5, 5);
            person = new Person(nameTest, birthDateTest, Gender.MALE);
        }

        [Test]
        public void TestPersonAgeCalculation()
        {
            int ageTest = DateTime.Now.Year - birthDateTest.Year;
            Assert.AreEqual(ageTest, person.Age);
        }

        [Test]
        public void TestPersonToString()
        {
            string stringTest = "Name: " + nameTest + ", Gender: " + Gender.MALE + ", Age: " + (DateTime.Now.Year - birthDateTest.Year) + ", BirthDate: " + birthDateTest.ToString("yyyy-MM-dd");
            Assert.AreEqual(stringTest, person.ToString());
        }

        [Test]
        public void 
    }
}
