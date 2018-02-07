using NUnit.Framework;
using System;

namespace WordLadder.Tests
{
    [TestFixture]
    public class RequestProcessorTests
    {
        static readonly string expectedError = "Incorrect number of parameters: Please check the input and try again:";

        [TestCase("too few params")]
        [TestCase("some   extra spaces")]
        [TestCase(" extra at start")]
        [TestCase("extra at end ")]
        [TestCase("just one too many params")]
        [Test]
        public void Error_shown_for_incorrect_number_of_parameters(string input)
        {
            var output = RequestProcessor.ProcessRequest(input);
            Assert.AreEqual(expectedError, output);
        }
    }
}
