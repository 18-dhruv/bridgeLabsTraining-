using NUnit.Framework;
using Regres;
namespace String_regrex
{
    [TestFixture]
    public class Test
    {
        private IStringCleaner verifier;
        [SetUp]
        public void Setup()
        {
            verifier = new EmailVerifier();
        }
        

        [TestCase("hello@gmail.com", true)]

        [TestCase("john.doe@gmail.com", true)]

        [TestCase("hello@gmail", false)]

        [TestCase("hello@124.12com", false)]

        [TestCase("hello@gmail.c", false)]

        [TestCase("hello@gmail.123", false)]

        public void EmailValidationTest(string email, bool expected)

        {

            bool result = verifier.IsStringCorrect(email);

            Assert.That(result, Is.EqualTo(expected));

        }
        
    }
}