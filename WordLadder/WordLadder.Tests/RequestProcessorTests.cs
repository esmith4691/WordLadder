using NUnit.Framework;
using System.IO;

namespace WordLadder.Tests
{
    [TestFixture]
    public class RequestProcessorTests
    {
        [SetUp]
        public void SetUp()
        {
            Directory.CreateDirectory(Path.Combine(TestHelper.GetAssemblyDirectory(), "output"));
        }

        [TearDown]
        public void TearDown()
        {
            Directory.Delete(Path.Combine(TestHelper.GetAssemblyDirectory(), "output"), recursive: true);
        }

        [Test]
        public void Error_shown_for_invalid_parameters()
        {
            var input = "invalid params";
            var output = RequestProcessor.ProcessRequest(input);
            var expectedError = "Invalid parameters: Please check the input and try again:";
            Assert.AreEqual(expectedError, output);
        }

        [Test]
        public void Error_shown_for_dictionary_load_failure()
        {
            var input = "fileNotExists.txt WORD CARD file.txt";
            var output = RequestProcessor.ProcessRequest(input);
            var expectedError = "No values loaded for dictionary: Please check file 'fileNotExists.txt'";
            Assert.AreEqual(expectedError, output);
        }

        [Test]
        public void Error_shown_for_result_writing_failure()
        {
            var input = $"{TestHelper.GetTestFilePath()} WORD WORD notWritableHere.txt";
            var output = RequestProcessor.ProcessRequest(input);
            var expectedError = "Error writing results: Please check file 'notWritableHere.txt'";
            Assert.AreEqual(expectedError, output);
        }

        [Test]
        public void Error_shown_when_no_path_exists()
        {
            var resultsPath = GetValidOutputPath();
            var input = $"{TestHelper.GetTestFilePath()} wash path {resultsPath}";
            var output = RequestProcessor.ProcessRequest(input);
            var expectedError = "No path found between WASH and PATH";
            Assert.AreEqual(expectedError, output);
        }

        [Test]
        public void Results_written_correctly_for_matching_words()
        {
            var resultsPath = GetValidOutputPath();
            var input = $"{TestHelper.GetTestFilePath()} word word {resultsPath}";
            var output = RequestProcessor.ProcessRequest(input);

            var expectedMessage = "Success! Results written to file";
            Assert.AreEqual(expectedMessage, output);

            var writtenContent = File.ReadAllLines(resultsPath);
            Assert.AreEqual(new[] { "WORD", "WORD" }, writtenContent);
        }

        [Test]
        public void Results_written_correctly_for_words_with_one_letter_different()
        {
            var resultsPath = GetValidOutputPath();
            var input = $"{TestHelper.GetTestFilePath()} word ward {resultsPath}";
            var output = RequestProcessor.ProcessRequest(input);

            var expectedMessage = "Success! Results written to file";
            Assert.AreEqual(expectedMessage, output);

            var writtenContent = File.ReadAllLines(resultsPath);
            Assert.AreEqual(new[] { "WORD", "WARD" }, writtenContent);
        }

        [Test]
        public void Results_written_correctly_for_words_with_one_several_different()
        {
            var resultsPath = GetValidOutputPath();
            var input = $"{TestHelper.GetTestFilePath()} wash pipe {resultsPath}";
            var output = RequestProcessor.ProcessRequest(input);

            var expectedMessage = "Success! Results written to file";
            Assert.AreEqual(expectedMessage, output);

            var writtenContent = File.ReadAllLines(resultsPath);
            Assert.AreEqual(new[] { "WASH", "WISH", "WISE", "WIPE", "PIPE" }, writtenContent);
        }

        private string GetValidOutputPath() => Path.Combine(TestHelper.GetAssemblyDirectory(), "output", "results.txt");
    }
}
