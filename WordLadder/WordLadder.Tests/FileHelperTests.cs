using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace WordLadder.Tests
{
    [TestFixture]
    public class FileHelperTests
    {
        static readonly string OutputDirectory = Path.Combine(TestHelper.GetAssemblyDirectory(), "output");

        [SetUp]
        public void SetUp()
        {
            Directory.CreateDirectory(OutputDirectory);
        }

        [TearDown]
        public void TearDown()
        {
            Directory.Delete(OutputDirectory, recursive: true);
        }

        [Test]
        public void Verify_result_written_correctly()
        {
            var content = new[] { "test", "results", "look", "like", "this" };
            var filename = Path.Combine(OutputDirectory, "testResult.txt");
            var result = FileHelper.TryWriteResult(filename, content );

            Assert.IsTrue(result);
            var fileContent = File.ReadAllLines(filename);
            Assert.AreEqual(content, fileContent);
        }

        [Test]
        public void Has_empty_collection_if_file_does_not_exist()
        {
            var words = FileHelper.LoadWordsFrom("FileDoesNotExist.txt");
            Assert.AreEqual(new List<string>(), words);
        }

        [Test]
        public void Returns_correct_words()
        {
            var expectedWords = new[] { "wash", "wish", "wise", "wipe", "pipe" };
            var filePath = TestHelper.GetTestFilePath();
            var words = FileHelper.LoadWordsFrom(filePath);
            Assert.AreEqual(expectedWords, words);
        }
    }
}
