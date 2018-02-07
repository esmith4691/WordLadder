using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLadder.Tests
{
    [TestFixture]
    public class RequestParametersTests
    {
        [Test, TestCaseSource(nameof(InvalidInputs))]
        public void No_parameters_created_for_incorrect_params(string input)
        {
            var result = RequestParameters.TryParseParams(input);
            Assert.IsNull(result);
        }

        [Test, TestCaseSource(nameof(ValidInputs))]
        public void Params_created_correctly_from_parmas(string input, string[] exValues )
        {
            var expectedDictionaryFile = exValues[0];
            var expectedStartWord = exValues[1];
            var expectedEndWord = exValues[2];
            var expectedResultFile = exValues[3];

            var result = RequestParameters.TryParseParams(input);

            Assert.AreEqual(expectedDictionaryFile, result.DictionaryFile);
            Assert.AreEqual(expectedStartWord, result.StartWord);
            Assert.AreEqual(expectedEndWord, result.EndWord);
            Assert.AreEqual(expectedResultFile, result.ResultFile);
        }

        private static IEnumerable<TestCaseData> InvalidInputs
        {
            get
            {
                yield return new TestCaseData("too few params");
                yield return new TestCaseData("some   extra spaces");
                yield return new TestCaseData(" extra at start");
                yield return new TestCaseData("extra at end ");
                yield return new TestCaseData("just one too many params");
            }
        }

        private static IEnumerable<TestCaseData> ValidInputs
        {
            get
            {
                yield return new TestCaseData("Correct number of params", new[] { "Correct", "number", "of", "params" });
                yield return new TestCaseData(" A few   extra spaces   ", new[] { "A", "few", "extra", "spaces" });
            }
        }
    }
}
