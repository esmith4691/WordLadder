using NUnit.Framework;

namespace WordLadder.Tests
{
    [TestFixture]
    public class RequestProcessorTests
    {
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
            var input = "fileNotExists.txt WORD WORD file.txt";
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
    }
}
