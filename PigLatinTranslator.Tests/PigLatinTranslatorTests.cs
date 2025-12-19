namespace PigLatinTranslator.Tests
{
    [TestFixture]
    public class PigLatinTranslatorTests
    {
        [Test]
        public void PigLatinTranslator_Test1()
        {
            string result = PigLatinTranslator.Translate("hello world");

            Assert.That(result, Is.EqualTo("ellohay orldway"));
        }

        [Test]
        public void PigLatinTranslator_Test2()
        {
            string result = PigLatinTranslator.Translate("Hello world");

            Assert.That(result, Is.EqualTo("Ellohay orldway"));
        }

        [Test]
        public void PigLatinTranslator_Test3()
        {
            string result = PigLatinTranslator.Translate("hello, world.");

            Assert.That(result, Is.EqualTo("ellohay, orldway."));
        }

        [Test]
        public void PigLatinTranslator_Test4()
        {
            string result = PigLatinTranslator.Translate("hello,  world");

            Assert.That(result, Is.EqualTo("ellohay,  orldway"));
        }

        [Test]
        public void PigLatinTranslator_Test5()
        {
            string result = PigLatinTranslator.Translate("hello everyone");

            Assert.That(result, Is.EqualTo("ellohay veryoneeway"));
        }
    }
}
