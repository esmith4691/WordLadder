using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

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
            var filePath = GetFilePath("testFile.txt");
            var result = sut.TryLoad(filePath);

            Assert.IsTrue(result);
            Assert.AreEqual(expectedWords, sut.Words);
        }

        string GetFilePath(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyFileName = assembly.Location;
            var assemblyDirectory = assemblyFileName.Remove(assemblyFileName.LastIndexOf('\\'));
            return Path.Combine(assemblyDirectory, "Resources", fileName);
        }
    }
}
