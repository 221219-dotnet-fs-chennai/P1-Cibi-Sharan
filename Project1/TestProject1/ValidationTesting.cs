//using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using BusinessLogic;

namespace TestProject1
{
    [TestFixture]
    public class ValidationTesting
    {
        Validation validation = new Validation();

        [Test]
        [TestCase("asdfghjkl@gmail.in", true)]
        [TestCase("qwertyu@dfghj.", false)]
        [TestCase("wxyzgmail.com", false)]
        [TestCase("nothing@gmail.good", true)]
        [TestCase("testemail@test.validation", false)]
        [TestCase("test1234@yahoo.in", true)]
        [TestCase("working@gmail.com", true)]
        [TestCase("dummyemail$email.in", false)]
        [TestCase("validation%yahoo.c", false)]
        [TestCase("goodjob@contact.in", true)]
        public void TestEmail(string email, bool val)
        {
            var emailisTrue = validation.ValidateEmail(email);
            Assert.AreEqual(emailisTrue, val);
        }

        [Test]
        [TestCase("8764832476", true)]
        [TestCase("238762", false)]
        [TestCase("+91 6765374864", true)]
        [TestCase("4589749687546498", false)]
        [TestCase("657-343-4324", true)]
        [TestCase("897.232.6445", true)]
        [TestCase("(216) 348 4387", true)]
        [TestCase("(634)(545)(5454)", false)]
        [TestCase("(656) 545-8238", true)]
        [TestCase("+1 (863) 376.3863", false)]
        public void TestPhoneNumber(string Phonenum, bool val)
        {
            var phone = validation.ValidatePhoneNumber(Phonenum);

            Assert.AreEqual(phone, val);
        }
    }
}