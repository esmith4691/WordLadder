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
        public void Has_empty_collection_if_file_does_not_exist()
        {
            sut.Load("FileDoesNotExist.txt");
            Assert.AreEqual(new List<string>(), sut.Words);
        }

        [Test]
        public void Returns_correct_words()
        {
            var expectedWords = new[] { "WASH", "WISH" };
            var filePath = TestHelper.GetTestFilePath();
            sut.Load(filePath);
            Assert.AreEqual(expectedWords, sut.Words);
        }
    }
}
