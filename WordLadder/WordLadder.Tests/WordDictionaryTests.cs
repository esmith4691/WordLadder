using NUnit.Framework;
using System.Collections.Generic;

namespace WordLadder.Tests
{
    [TestFixture]
    public class WordDictionaryTests
    {
        WordDictionary sut;

        [SetUp]
        public void Setup()
        {
            sut = new WordDictionary();
        }

        [Test]
        public void Instantiates_collection_correctly()
        {
            Assert.AreEqual(new List<string>(), sut.Words);
        }

        [Test]
        public void Returns_false_if_file_does_not_exist()
        {
            var result = sut.TryLoad("FileDoesNotExist.txt");
            Assert.IsFalse(result);
            Assert.AreEqual(new List<string>(), sut.Words);
        }

        [Test]
        public void Returns_correct_words()
        {
            var expectedWords = new[] { "WASH", "WISH" };
            var filePath = TestHelper.GetTestFilePath();
            var result = sut.TryLoad(filePath);

            Assert.IsTrue(result);
            Assert.AreEqual(expectedWords, sut.Words);
        }
    }
}
