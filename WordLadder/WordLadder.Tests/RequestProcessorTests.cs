using NUnit.Framework;
using System;

namespace WordLadder.Tests
{
    [TestFixture]
    public class RequestProcessorTests
    {
        [Test]
        public void Error_shown_for_incorrect_number_of_parameters()
        {
            var input = "invalid params";
            var output = RequestProcessor.ProcessRequest(input);
            var expectedError = "Invalid parameters: Please check the input and try again:";
            Assert.AreEqual(expectedError, output);
        }
    }
}
