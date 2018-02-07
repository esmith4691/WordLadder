using NUnit.Framework;
using System.Collections.Generic;

namespace WordLadder.Tests
{
    [TestFixture]
    public class RequestParametersTests
    {
        static readonly string validFile = "file.txt";
        static readonly string invalidFile = "file.csv";
        static readonly string validWord = "word";
        static readonly string invalidWord = "w_rd";

        [Test, TestCaseSource(nameof(InvalidParamsInputs))]
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
        
        private static IEnumerable<TestCaseData> InvalidParamsInputs
        {
            get
            {
                yield return new TestCaseData($"{validFile} {validWord} {validWord}");
                yield return new TestCaseData($"{validFile} {validWord} {validWord} {validFile} extra");
                yield return new TestCaseData($"{invalidFile} {validWord} {validWord} {validFile}");
                yield return new TestCaseData($"{validFile} {validWord} {validWord} {invalidFile}");
                yield return new TestCaseData($"{validFile} {invalidWord} {validWord} {validFile}");
                yield return new TestCaseData($"{validFile} {validWord} {invalidWord} {validFile}");
            }
        }

        private static IEnumerable<TestCaseData> ValidInputs
        {
            get
            {
                yield return new TestCaseData($"{validFile} {validWord} wait a{validFile}", 
                        new[] { validFile, validWord, "wait", "a" + validFile });
                yield return new TestCaseData($" {validFile} {validWord}   {validWord} {validFile}   ", 
                        new[] { validFile, validWord, validWord, validFile });
            }
        }
    }
}
